using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GieldaL2.API.Filters
{
    /// <summary>
    /// Filter calculating total time spent on the backend logic.
    /// </summary>
    public class BackendTimeFilter : IActionFilter
    {
        private readonly Stopwatch _stopWatch = new Stopwatch();

        /// <summary>
        /// Initializes a new instance of the <see cref="OnActionExecuting"/> class.
        /// </summary>
        /// <param name="filterContext">Filter context passed by the ASP engine.</param>
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _stopWatch.Reset();
            _stopWatch.Start();
        }

        /// <summary>
        /// Called after the action executes, before the action result.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext" />.</param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var executionTime = (int)_stopWatch.ElapsedMilliseconds;

            if (!(context.Result is NotFoundResult))
            {
                var responseObject = (ObjectResult)context.Result;
                var backendTimeProperty = responseObject.Value.GetType().GetProperty("BackendTime");

                backendTimeProperty?.SetValue(responseObject.Value, executionTime);
            }
        }
    }
}
