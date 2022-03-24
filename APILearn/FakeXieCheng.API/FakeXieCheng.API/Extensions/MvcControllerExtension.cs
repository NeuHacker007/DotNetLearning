using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace FakeXieCheng.API.Extensions
{
    public static class MvcControllerExtension
    {
        public static void AddMvcControllerSettingsServices(this IServiceCollection services)
        {
            services.AddControllers(setup =>
            {
                setup.ReturnHttpNotAcceptable = true;
                //setup.OutputFormatters.Add(
                //    new XmlDataContractSerializerOutputFormatter());
            })
            .AddNewtonsoftJson(setup =>
            {
                setup.SerializerSettings.ContractResolver =
                                new CamelCasePropertyNamesContractResolver();
            })
            .AddXmlDataContractSerializerFormatters()
            .ConfigureApiBehaviorOptions(setup =>
            {
                setup.InvalidModelStateResponseFactory = context =>
                {
                    var problemDetail = new ValidationProblemDetails(context.ModelState)
                    {
                        Type = "数据验证失败",
                        Title = "数据验证失败",
                        Status = StatusCodes.Status422UnprocessableEntity,
                        Detail = "请看详细说明",
                        Instance = context.HttpContext.Request.Path
                    };

                    problemDetail.Extensions.Add("traceId", context.HttpContext.TraceIdentifier);

                    return new UnprocessableEntityObjectResult(problemDetail)
                    {
                        ContentTypes = { "application/problem+json" }
                    };
                };
            });
        }
    }
}
