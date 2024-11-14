using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Restrike.GitHubIntegration.Api.Exceptions
{
    public class CustomUnprocessableEntityObjectResult : UnprocessableEntityObjectResult
    {
        public CustomUnprocessableEntityObjectResult(ModelStateDictionary modelState,
            IDictionary<int, ClientErrorData> clientMappingOptions, HttpContext contextHttpContext) : base(modelState)
        {
            var errors = new Dictionary<string, IEnumerable<FieldError>>();
            foreach (var modelStateKey in modelState.Keys)
            {
                if (modelState.GetValidationState(modelStateKey) == ModelValidationState.Invalid)
                {
                    var errorMessages = modelState[modelStateKey].Errors.Select(x => new FieldError { Message = x.ErrorMessage });
                    errors.Add(modelStateKey, errorMessages);
                }
            }

            var unprocessableEntityStatusCode = (int)HttpStatusCode.UnprocessableEntity;
            Value = new UnprocessableEntityModel
            {
                Title = clientMappingOptions[unprocessableEntityStatusCode].Title,
                Type = clientMappingOptions[unprocessableEntityStatusCode].Link,
                Status = unprocessableEntityStatusCode,
                TraceId = contextHttpContext.TraceIdentifier,
                Errors = errors
            };
        }
    }

    public class UnprocessableEntityModel
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public string Type { get; set; }
        public string TraceId { get; set; }
        public Dictionary<string, IEnumerable<FieldError>> Errors { get; set; }
    }

    public class FieldError
    {
        public string Message { get; set; }
    }
}
