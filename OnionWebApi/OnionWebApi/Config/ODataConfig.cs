using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.OData;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData;
using OnionWebApi.Models.Entities;
using OnionWebApi.BL.Dtos;
using Microsoft.AspNetCore.Builder;

namespace OnionWebApi.Config
{
    public static class ODataConfig
    {
        public static IServiceCollection ConfigOData(this IServiceCollection services)
        {

            return services;
        }
    }
}

