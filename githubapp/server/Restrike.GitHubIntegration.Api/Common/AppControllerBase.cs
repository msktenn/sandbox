using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using System.Net.Mime;
using System.Security.Claims;

namespace Restrike.GitHubIntegration.Api.Common
{
    [Authorize]
    [ApiController]
    [ApiVersion("1")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ResponseCache(NoStore = true)] // tell IE11 not to cache json responses
    public class AppControllerBase : ControllerBase
    {
        private IHttpContextAccessor _contextAccessor = null;


        public AppControllerBase()
        {

        }

        public AppControllerBase(IHttpContextAccessor contextAccessor)
             : this()
        {

        }
    }

    public class AppControllerBase<T> : AppControllerBase
    {
        protected T _domain { get; private set; }

        public AppControllerBase(T domain) : base()
        {
            _domain = domain;
        }

        public AppControllerBase(T domain, IHttpContextAccessor contextAccessor) : this(domain) { }
    }
}
