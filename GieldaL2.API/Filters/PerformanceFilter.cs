using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GieldaL2.API.Filters
{
    public class BackendTimeFilter : IActionFilter
    {
        private readonly Stopwatch _stopWatch = new Stopwatch();

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _stopWatch.Reset();
            _stopWatch.Start();
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var executionTime = (int)_stopWatch.ElapsedMilliseconds;
            var responseObject = (ObjectResult)filterContext.Result;
            var backendTimeProperty = responseObject.Value.GetType().GetProperty("BackendTime");

            backendTimeProperty?.SetValue(responseObject.Value, executionTime);
        }
    }
}
