using Restrike.GitHubIntegration.Api.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Restrike.GitHubIntegration.Api.Exceptions
{    /// <summary>
     /// Custom exception handling middleware that is responsible for catching specific exceptions and handling
     /// them by transforming the HTTP response. Exception types not caught here will be picked up by the default
     /// exception handler and converted to an HTTP 500 internal server error.
     /// </summary>
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly IDictionary<int, ClientErrorData> _clientErrorMapping;

        public ExceptionHandlerMiddleware(RequestDelegate next, IOptions<ApiBehaviorOptions> options)
        {
            _next = next;


            _clientErrorMapping = options.Value.ClientErrorMapping;

            //There was something wrong with passing the the 500 up
            //var d = options.Value.ClientErrorMapping;
            //if (!d.ContainsKey(500))
            //    d.Add(500, new ClientErrorData { Title = "Internal Server Error" });
            //_clientErrorMapping = d;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (EntityNotFoundException e)
            {
                await ProcessException(context, e);
            }
            catch (EntityInUseException e)
            {
                await ProcessException(context, e);
            }
            catch (RequestValidationException e)
            {
                await ProcessException(context, e);
            }
            catch (UnauthorizedException e)
            {
                await ProcessException(context, e);
            }
            catch (Exception e) when (e is ArgumentException || e is SystemException)
            {
                await ProcessException(context, e);
            }
            catch (Exception e)
            {
                await ProcessException(context, e);
            }
        }

        private async Task ProcessException(HttpContext context, EntityNotFoundException exception)
        {
            Log.Information(exception, $"{exception.GetType().Name}: {exception.Message}");
            const int NotFoundStatusCode = (int)HttpStatusCode.NotFound;
            context.Response.StatusCode = NotFoundStatusCode;

            await WriteJsonResponse(context, new ValidationResponseModel
            {
                Title = _clientErrorMapping[NotFoundStatusCode].Title,
                Type = _clientErrorMapping[NotFoundStatusCode].Link,
                Status = NotFoundStatusCode,
                TraceId = context.TraceIdentifier,
            });
        }

        private async Task ProcessException(HttpContext context, EntityInUseException exception)
        {
            Log.Information(exception, $"{exception.GetType().Name}: {exception.Message}");
            const int StatusCode = StatusCodes.Status409Conflict;
            var clientErrorData = _clientErrorMapping[StatusCode];
            context.Response.StatusCode = StatusCode;

            await WriteJsonResponse(context, new ErrorMessageResponseModel
            {
                Title = clientErrorData.Title,
                Type = clientErrorData.Link,
                Status = StatusCode,
                TraceId = context.TraceIdentifier,
                ErrorMessage = exception.Message
            });
        }

        private async Task ProcessException(HttpContext context, RequestValidationException exception)
        {
            Log.Information(exception, $"{exception.GetType().Name}: {exception.Message}");
            const int StatusCode = (int)HttpStatusCode.UnprocessableEntity;
            context.Response.StatusCode = StatusCode;
            await WriteJsonResponse(context, new UnprocessableEntityResponseModel
            {
                TraceId = context.TraceIdentifier,
                Errors = exception.Errors,
                Title = _clientErrorMapping[StatusCode].Title,
                Type = _clientErrorMapping[StatusCode].Link,
                Status = StatusCode
            });
        }

        private async Task ProcessException(HttpContext context, Exception exception, HttpStatusCode statusCode)
        {
            Log.Error(exception, $"{exception.GetType().Name}: {exception.Message}");

            context.Response.StatusCode = (int)statusCode;
            await WriteJsonResponse(context, new ValidationResponseModel
            {
                Title = _clientErrorMapping[context.Response.StatusCode].Title,
                Type = _clientErrorMapping[context.Response.StatusCode].Link,
                Status = context.Response.StatusCode,
                TraceId = Activity.Current?.Id ?? context.TraceIdentifier
            });
        }

        private async Task ProcessException(HttpContext context, UnauthorizedException exception)
        {
            Log.Information(exception, $"{exception.GetType().Name}: {exception.Message}");
            const int StatusCode = StatusCodes.Status401Unauthorized;
            var clientErrorData = _clientErrorMapping[StatusCode];
            context.Response.StatusCode = StatusCode;

            await WriteJsonResponse(context, new ValidationResponseModel
            {
                Title = clientErrorData.Title,
                Type = clientErrorData.Link,
                Status = StatusCode,
                TraceId = context.TraceIdentifier,
            });
        }

        private async Task ProcessException(HttpContext context, Exception exception)
             => await ProcessException(context, exception, HttpStatusCode.InternalServerError);

        private async Task WriteJsonResponse<TResponseBody>(HttpContext context, TResponseBody body)
        {
            context.Response.ContentType = "application/json";
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var content = JsonSerializer.Serialize(body, options);

            await context.Response.WriteAsync(content);
        }
    }

    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
