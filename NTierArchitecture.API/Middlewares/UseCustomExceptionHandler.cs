using Microsoft.AspNetCore.Diagnostics;
using NTierArchitecture.Business.Exceptions;
using NTierArchitecture.DTO.DTOs;
using System.Text.Json;

namespace NTierArchitecture.API.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomExcepiton(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideExcepiton => 400,
                        _ => 500
                    };

                    context.Response.StatusCode = statusCode;

                    var response = CustomResponseDto<string>.Fail(statusCode, exceptionFeature.Error.Message);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });

        }
    }
}
