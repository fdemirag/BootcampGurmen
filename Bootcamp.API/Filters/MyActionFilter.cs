using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Bootcamp.API.Filters
{
    public class MyActionFilter :ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Debug.WriteLine("Action Method çağırılmadan önce");
            await next.Invoke();
            Debug.WriteLine("Action Method çağırıldıktan sonra");
        }

        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            Debug.WriteLine("Result çağırılmadan önce");
            await next.Invoke();
            Debug.WriteLine("Result çağırıldıktan sonra");
        }



    }
}
