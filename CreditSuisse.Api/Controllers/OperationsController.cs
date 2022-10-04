using AutoMapper;
using CreditSuisse.Api.Models;
using CreditSuisse.Application.Interfaces;
using CreditSuisse.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditSuisse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : Controller
    {
        #region Métodos Privados
        private readonly IMapper _mapper;
        private readonly ITradeAppService _tradeAppService;
        private readonly ICategoryAppService _categoryAppService;
        #endregion

        #region Construtor       
        public OperationsController(IMapper mapper, ITradeAppService tradeAppService, ICategoryAppService categoryAppService)
        {
            _mapper = mapper;
            _tradeAppService = tradeAppService;
            _categoryAppService = categoryAppService;
        }
        #endregion

        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var cat = await _categoryAppService.GetAll();

                return Ok(cat);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);

            }
        }


        [HttpPost("GetTradeInfo")]
        public async Task<IActionResult> GetTradeInfo([FromBody] Models.OperationModel operationModel)
        {
            try
            {
                var cat = await _categoryAppService.GetAll();
                var retorno = new List<string>();


                foreach (var item in operationModel?.Trades)
                {

                    if (operationModel.ReferenceDate.AddDays(-30) > item.NextPaymentDate)
                    {
                        retorno.Add("EXPIRED");
                        continue;
                    }

                    var sector = cat.Where(c => c.Sector?.ToUpper() == item.ClientSector?.ToUpper())?.FirstOrDefault();

                    if (item.Value > sector.Value)
                    {
                        retorno.Add(sector.Name);
                    }
                }

                return Json(retorno);

            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("InsertCategory")]
        public async Task<IActionResult> InsertNewCategory([FromBody] CategoryModel categoryModel)
        {
            try
            {
                var catModel = _mapper.Map<Category>(categoryModel);
                var result = await _categoryAppService.Insert(catModel);

                return Json(result);

            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
