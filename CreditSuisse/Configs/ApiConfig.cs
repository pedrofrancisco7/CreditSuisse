using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace CreditSuisse.Configs
{
    public static class ApiConfig
    {
        public static IServiceCollection WebApiConfig(this IServiceCollection services)
        {
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
                options.AssumeDefaultVersionWhenUnspecified = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("Development",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            return services;

        }

        public static IApplicationBuilder UserMvcConfiguration(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            //app.UseMvc();            
            app.UseCors("Development");

            return app;
        }
    }
}
