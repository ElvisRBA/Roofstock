using System.Linq;
using API.Errors;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    // In this class I'm adding some services so I don't have all the code inside the startup file.
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Adding the service so the API knows about the RealProrpertyService.
            services.AddScoped<IRealPropertyService, RealPropertyService>();
            // Adding the UnitOfWork implementation so I can make use of it all over the app.
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            // Adding the GenericRepository implementation so I can make use of it all over the app.
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            // This is created to extract the errors if there are any and populates the error messages into an array.
            // And that's the array will pass into the ApiValidationErrorResponse
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(x => x.Value.Errors)
                        .Select(x => x.ErrorMessage).ToArray();
                    
                    var errorResponse = new ApiValidationErrorResponse
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });

            return services;
        }
    }
}