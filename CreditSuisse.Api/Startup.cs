using CreditSuisse.Api.Configuration;
using CreditSuisse.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CreditSuisse.Api
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
            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CreditSuisse.Api", Version = "v1" });
                
            });

            InitializeContainer(services);

            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin", builder => builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod());
            });


            services.AddAutoMapper(typeof(Startup));
            services.WebApiConfig();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseDeveloperExceptionPage();
            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CreditSuisse.Api v1"));


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UserMvcConfiguration();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private static void InitializeContainer(IServiceCollection services)
        {
            AutoMapperConfig.RegisterMapping(services);
            Bindings.Start(services);
            Bindings.RegisterMappings();
        }
    }
}
