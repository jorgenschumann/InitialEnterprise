using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InitialEnterprise.Infrastructure.Api.Attributes
{
    public class HeaderAddAttribute : Attribute, IFilterFactory
    {
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return new InternalAddHeaderFilter();
        }

        public bool IsReusable => false;

        private class InternalAddHeaderFilter : IResultFilter
        {
            public void OnResultExecuting(ResultExecutingContext context)
            {
                //context.HttpContext.Response.Headers.Add("Internal", new string[] { "Header Added" });
            }

            public void OnResultExecuted(ResultExecutedContext context)
            {
            }
        }
    }
}