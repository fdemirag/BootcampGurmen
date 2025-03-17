using System.Net;

namespace Bootcamp.API.Middlewares
{
    public class IPAddressControlMiddleware
    {
        private readonly RequestDelegate requestDelegate;
        private readonly IConfiguration _configuration;
        public IPAddressControlMiddleware(RequestDelegate requestDelegate, IConfiguration configuration)
        {
            this.requestDelegate = requestDelegate;
            _configuration = configuration;
        }

     

        public async Task InvokeAsync(HttpContext context) 
        {
            var reqIpAddress = context.Connection.RemoteIpAddress;

            if (IPAddress.Parse(_configuration["WhiteIPAddress"]).Equals(reqIpAddress))
            {
                await requestDelegate.Invoke(context);
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                await context.Response.WriteAsync("Forbidden");

            }
        }
    }
}
