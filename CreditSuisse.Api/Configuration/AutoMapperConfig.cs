using AutoMapper;
using CreditSuisse.Api.Models;
using CreditSuisse.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace CreditSuisse.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public static void RegisterMapping(IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryModel, Category>();
                cfg.CreateMap<Category, CategoryModel>();
                //cfg.CreateMap<UsuarioModel, Usuario>();
                //cfg.CreateMap<Usuario, UsuarioModel>();

            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
