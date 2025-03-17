using Bootcamp.API.DTOs;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Bootcamp.API.Filters
{
    public class CustomExceptionFilter:ExceptionFilterAttribute
    {
        public override Task OnExceptionAsync(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            //var exceptionFeature = context.HttpContext.Features.Get<IExceptionHandlerFeature>();

            //var exception = exceptionFeature.Error;


            Debug.WriteLine("Exception filter Çalıştı");

            context.Result = new ObjectResult(ResponseDto<NoContent>.Fail($"{context.Exception.Message}", 500)){ StatusCode = 500 };

            return Task.CompletedTask;
            //return base.OnExceptionAsync(context);
        }
    }
}
