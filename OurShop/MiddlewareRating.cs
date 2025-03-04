using Entits;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Services;
using System;
using System.Threading.Tasks;

namespace OurShop
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MiddlewareRating
    {
        private readonly RequestDelegate _next;

        public MiddlewareRating(RequestDelegate next)
        {
            _next = next;
        }

        public  async Task Invoke(HttpContext httpContext, IRatingServices ratingService)
        {

            Rating ratin = new();
            ratin.Method = httpContext.Request.Method;
            ratin.Host = httpContext.Request.Host.ToString();
            ratin.Path = httpContext.Request.Path.Value;
            ratin.UserAgent = httpContext.Request.Headers.UserAgent;
            ratin.Referer = httpContext.Request.Headers.Referer;
            ratin.RecordDate = DateTime.Now;
   
            await ratingService.AddRating(ratin);
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareRatingExtensions
    {
        public static IApplicationBuilder UseMiddlewareRating(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareRating>();
        }
        
    }
}
