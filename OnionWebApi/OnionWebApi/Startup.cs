using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OnionWebApi.BL.Config;
using OnionWebApi.Config;
using OnionWebApi.Core;
using OnionWebApi.Models.Contexts;
using OnionWebApi.Presentation.Config;
using OnionWebApi.Services.IoC;
using OnionWebApi.Services.Services;
using System;

namespace OnionWebApi.Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            #region Libraries
            AutoMapperConfig.AddAutoMapperConfig(services);

            SwaggerConfig.AddSwaggerConfig(services);

            CorsConfig.AddCorsConfig(services);

            ODataConfig.ConfigOData(services);
            #endregion

            #region AppRegistry
            ServiceRegistry.AddServiceRegistry(services);
            #endregion

            #region ConnectionStrings
            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));

            services.AddDbContext<BaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );
            #endregion

            services.AddControllers().AddOData(opt => opt
                         .Select().Expand().Filter().Count().OrderBy()); ;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                SwaggerConfig.AddSwaggerUI(app);
                app.UseDeveloperExceptionPage();
            }

            CorsConfig.AddCorsApp(app);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}