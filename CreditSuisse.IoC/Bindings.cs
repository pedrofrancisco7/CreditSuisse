using CreditSuisse.Application.Interfaces;
using CreditSuisse.Application.Services;
using CreditSuisse.Data.Context;

using CreditSuisse.Data.Mapping;
using CreditSuisse.Data.Repository;
using CreditSuisse.Domain.Interfaces.Repository;
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
            services.AddScoped<ICategoryAppService, CategoryAppService>();
            services.AddScoped<ITradeAppService, TradeAppService>();            
            #endregion

            #region Domain
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<ITradeService, TradeService>();
            services.AddScoped<ICategoryService, CategoryService>();
            #endregion

            #region Infra            
            services.AddScoped<ITradeRepository, TradeRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            #endregion

            services.AddSingleton<CreditSuisseContext>();
        }

        public static void RegisterMappings()
        {
            RegisterMapping.Initialize();
        }
    }

}
