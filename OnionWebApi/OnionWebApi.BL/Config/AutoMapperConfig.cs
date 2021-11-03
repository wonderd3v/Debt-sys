using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionWebApi.BL.Config
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
