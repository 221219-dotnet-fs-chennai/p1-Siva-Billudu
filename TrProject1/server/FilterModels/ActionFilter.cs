using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace server.FilterModels
{
    public class ActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine("Action filter Finished - After Logic");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Debug.WriteLine("Action filter Finished - Before Logic");
        }
    }
}
