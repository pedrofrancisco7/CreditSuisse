using CreditSuisse.Application.Interfaces;
using CreditSuisse.Application.Services;
using CreditSuisse.Data.Context;
using CreditSuisse.Data.Interfaces.Repository;
using CreditSuisse.Data.Mapping;
using CreditSuisse.Data.Repository;
using CreditSuisse.Domain.Interfaces.Services;
using CreditSuisse.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CreditSuisse.IoC
{
    public class Bindings
    {
        public static void Start(IServiceCollection services)
        {
            #region Application
            services.AddScoped(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
            //services.AddScoped<IAppServiceTrade, AppServiceTrade>();
            services.AddScoped<IAppServiceCategory, AppServiceCategory>();
            #endregion

            //#region Domain
            //services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            //services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            //services.AddScoped<IServiceTrade, ServiceTrade>();
            //services.AddScoped<IServiceCategory, ServiceCategory>();            
            //#endregion

            //#region Infra           
            //services.AddScoped<IRepositoryTrade, RepositoryTrade>();
            //services.AddScoped<IRepositoryCategory, RepositoryCategory>();
            //#endregion

            services.AddSingleton<CreditSuisseContext>();

        }

        public static void RegisterMappings()
        {
            RegisterMapping.Initialize();
        }
    }
}
