using CreditSuisse.Application.Interfaces;
using CreditSuisse.Domain.Entities;
using CreditSuisse.Domain.Interfaces.Services;

namespace CreditSuisse.Application.Services
{
    public class TradeAppService : AppServiceBase<Trade>, ITradeAppService
    {
        private readonly ITradeService _vivoAppService;
        public TradeAppService(ITradeService vivoAppService) : base(vivoAppService)
        {
            _vivoAppService = vivoAppService;
        }
    }
}
