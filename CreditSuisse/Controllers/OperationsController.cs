using AutoMapper;
using CreditSuisse.Application.Interfaces;
using CreditSuisse.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CreditSuisse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : Controller
    {
        #region Privates Methods
        private readonly IMapper _mapper;
        //private readonly IAppServiceTrade _tradeAppService;
        private readonly IAppServiceCategory _categoryAppService;
        #endregion

        #region Constructor       
        public OperationsController(IMapper mapper, /*IAppServiceTrade tradeAppService,*/ IAppServiceCategory categoryAppService)
        {
            _mapper = mapper;
            //_tradeAppService = tradeAppService;
            _categoryAppService = categoryAppService;
        }
        #endregion

        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {

                var category = await _categoryAppService.GetAll();
                return Ok(category);

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
