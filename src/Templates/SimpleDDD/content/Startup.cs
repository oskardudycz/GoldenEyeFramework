using GoldenEye.Backend.Core.DDD.Registration;
using GoldenEye.Backend.Core.WebApi.Modules;
using GoldenEye.Backend.Core.WebApi.Registration;
using GoldenEye.Shared.Core.Configuration;
using GoldenEye.Shared.Core.Mappings;
using GoldenEye.Shared.Core.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GoldenEye.WebApi.Template.SimpleDDD
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
            services.AddMvc();
            services.AddDDD();

            services.AddAllDDDHandlers();

            services.AddAutoMapperForAllDependencies();
            services.AddConfiguration(Configuration);

            services.AddAllModules();
            services.AddModule<AllowAllCorsModule>();
            services.AddModule<SwaggerModule>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionHandlingMiddleware();
            //TODO: Fix template after publishing NuGets
            //app.UseModules(env);

            app.UseMvc();
        }
    }
}
