//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;

//namespace AccessData.Action
//{
//    public class Actions : ActionFilterAttribute
//    {
//        private readonly RequestDelegate _next;
//        private readonly ILogger<Actions> _logger;

//        public Actions(RequestDelegate next, ILogger<Actions> logger)
//        {
//            _next = next;
//            _logger = logger;
//        }

//        public async Task InvokeAsync(HttpContext context)
//        {
//            var stopwatch = Stopwatch.StartNew();


//            _logger.LogInformation("Incoming request: {Method} {Url}", context.Request.Method, context.Request.Path);


//            await _next(context);


//            stopwatch.Stop();
//            _logger.LogInformation("Outgoing response: {StatusCode} | Request Processing Time: {ElapsedMilliseconds}ms",
//                context.Response.StatusCode, stopwatch.ElapsedMilliseconds);
//        }
//    }
//}