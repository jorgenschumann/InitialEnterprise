using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace InitialEnterprise.Infrastructure.Api.Filter
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly IHostingEnvironment env;
        private readonly ILogger<HttpGlobalExceptionFilter> logger;

        public HttpGlobalExceptionFilter(IHostingEnvironment env, ILogger<HttpGlobalExceptionFilter> logger)
        {
            this.env = env;
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            logger.LogError(new EventId(context.Exception.HResult),
                context.Exception,
                context.Exception.Message);

            var jsonErrorResponse = new JsonErrorResponse
            {
                Messages = new[] {"error occur"}
            };

            if (env.IsDevelopment()) jsonErrorResponse.DeveloperMessage = context.Exception;

            context.Result = new InternalServerErrorObjectResult(jsonErrorResponse);
            context.HttpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

            context.ExceptionHandled = true;
        }

        private class JsonErrorResponse
        {
            public string[] Messages { get; set; }

            public object DeveloperMessage { get; set; }
        }
    }
}