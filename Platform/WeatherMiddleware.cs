﻿using Platform.Services;

namespace Platform
{
    public class WeatherMiddleware
    {
        private RequestDelegate next;

        //private IResponseFormatter formatter;

        public WeatherMiddleware(RequestDelegate nextDelegate, IResponseFormatter respFormatter)
        {
            next = nextDelegate;
            // formatter = respFormatter;
        }

        public async Task Invoke(HttpContext context,
            IResponseFormatter formatter1,
            IResponseFormatter formatter2,
            IResponseFormatter formatter3)
        {
            if (context.Request.Path == "/middleware/class")
            {
                await formatter1.Format(context, string.Empty);
                await formatter2.Format(context, string.Empty);
                await formatter3.Format(context, string.Empty);
            }
            else
            {
                await next(context);
            }
        }
    }
}