using CreditSuisse.Domain.Entities;
using CreditSuisse.Domain.Interfaces.Repository;
using CreditSuisse.Domain.Interfaces.Services;

namespace CreditSuisse.Domain.Services
{
    public class TradeService : ServiceBase<Trade>, ITradeService
    {
        private readonly ITradeRepository _tradeRepository;

        public TradeService(ITradeRepository tradeRepository) : base(tradeRepository)
        {
            _tradeRepository = tradeRepository;
        }   
    }
}
