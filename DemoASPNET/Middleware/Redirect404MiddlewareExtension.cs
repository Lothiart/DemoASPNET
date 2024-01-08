using System.Runtime.CompilerServices;

namespace DemoASPNET.Middleware
{
    public static class Redirect404MiddlewareExtension
    {
        public static IApplicationBuilder USeRedirect404( this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Redirect404Middleware>();

        }


        
    }
}
