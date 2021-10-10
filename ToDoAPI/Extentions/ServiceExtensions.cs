using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAPI.Extentions
{
    public static class ServiceExtensions
    {
        public static void RegisterSwagger(this IServiceCollection serviceprovider) {
            serviceprovider.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ToDoAPI", Version = "v1" });
            });
        }
    }
}
