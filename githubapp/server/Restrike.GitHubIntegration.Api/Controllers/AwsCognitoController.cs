using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Serilog;

namespace Restrike.GitHubIntegration.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [SwaggerTag("Operations for non-authenticated users")]
    public class AwsCognitoController : ControllerBase
    {


        public AwsCognitoController()
        {
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            var retVal = new string[] { "a", "b" };
            return retVal;
        }
    }
}
