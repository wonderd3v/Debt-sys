using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnionWebApi.Config
{
    public class CorsConfig
    {
        public static void AddCorsConfig(IServiceCollection service)
        {
            service.AddCors();
        }

        public static void AddCorsApp(IApplicationBuilder application)
        {
            application.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true)
               .AllowCredentials());
        }
    }
}
