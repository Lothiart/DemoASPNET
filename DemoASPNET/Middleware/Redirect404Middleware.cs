﻿namespace DemoASPNET.Middleware
{
    public class Redirect404Middleware
    {
        private readonly RequestDelegate _next;
        public Redirect404Middleware(RequestDelegate next) {  _next = next; }
        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
            if (context.Response.StatusCode == 404)
            {
                context.Response.Redirect("/Home/MyError404" , false);
            }
        }
    }
}
