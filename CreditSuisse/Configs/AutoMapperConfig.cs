using AutoMapper;
using CreditSuisse.Domain.Entities;
using CreditSuisse.Models;
using Microsoft.Extensions.DependencyInjection;

namespace CreditSuisse.Configs
{
    public class AutoMapperConfig : Profile
    {
        public static void RegisterMapping(IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TradeModel, Trade>();
                cfg.CreateMap<Trade, TradeModel>();
                cfg.CreateMap<CategoryModel, Category>();
                cfg.CreateMap<Category, CategoryModel>();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
