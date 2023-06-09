﻿namespace RIT.Api.Middlewares;

public static class ExceptionMiddleware
{
    public static void UseValidationException(this IApplicationBuilder app)
    {
        app.Use(async (context, next) =>
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(new {exception.Message});
            }
        });
    }
}