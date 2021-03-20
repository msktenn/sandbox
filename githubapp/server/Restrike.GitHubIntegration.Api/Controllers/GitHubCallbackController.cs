using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using Serilog;
using System.IO;
using Microsoft.AspNetCore.Http.Extensions;

namespace Restrike.GitHubIntegration.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [SwaggerTag("Operations for non-authenticated users")]
    public class GitHubCallbackController : ControllerBase
    {

        public GitHubCallbackController()
        {

        }

        [HttpGet]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "")]
        public ActionResult<string[]> Get()
        {
            Log.Debug("public ActionResult Patch()");
            LogRequest();
            var result = new List<string>() { "a", "b", "c" };
            return Ok(result);

        }

        [HttpPost]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "")]
        public ActionResult Post()
        {
            Log.Debug("public ActionResult Patch()");
            LogRequest();
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            Log.Debug("public ActionResult Patch()");
            LogRequest();
            return NoContent();
        }

        [HttpPut]
        public ActionResult Put()
        {
            Log.Debug("public ActionResult Patch()");
            LogRequest();
            return NoContent();
        }

        [HttpPatch]
        public ActionResult Patch()
        {
            Log.Debug("Called: public ActionResult Patch()");
            LogRequest();
            return NoContent();
        }
        private void LogRequest()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var body = reader.ReadToEndAsync();
                Log.Information("------------------------Begin LogRequest----------------------------");
                Log.Information($"URL: {UriHelper.GetEncodedUrl(HttpContext.Request)}");
                Log.Information("");
                Log.Information($"    {Request.Method} {Request.Path} {Request.Protocol} ");
                foreach (var header in Request.Headers)
                {
                    Log.Information($"    {header.Key}: {header.Value}");
                }
                Log.Information("");
                body.Wait();
                Log.Information($"    {body.Result}");
                Log.Information("------------------------End LogRequest----------------------------");
            }
        }
    }
}