using CreditSuisse.Application.Interfaces;
using CreditSuisse.Domain.Entities;
using CreditSuisse.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditSuisse.Application.Services
{
    public class AppServiceTrade : AppServiceBase<Trade>, IAppServiceTrade
    {
        private readonly IServiceTrade _tradeAppService;
        public AppServiceTrade(IServiceTrade tradeAppService) : base(tradeAppService)
        {
            _tradeAppService = tradeAppService;
        }        
    }
}
