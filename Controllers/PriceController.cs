using Microsoft.AspNetCore.Mvc;
//using Microsoft.OpenApi.Models;
//using System.ComponentModel.DataAnnotations;
using VATCalculator.Models;
using VATCalculator.Repositories.Interfaces;
using VATCalculator.Validation;
//using System.Collections.Generic;

namespace VATCalculator.Controllers
{
    /// <summary>
    /// Controller for VAT calculations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly IPriceCalculatorRepository _priceCalculatorRepository;

        /// <summary>
        /// PriceController constructor
        /// </summary>
        /// <param name="priceCalculatorRepository">VAT calculation logic repository</param>
        public PriceController(IPriceCalculatorRepository priceCalculatorRepository)
        {
            _priceCalculatorRepository = priceCalculatorRepository;
        }

        /// <summary>
        /// Calculate VAT amount and price total from base price and VAT percentile
        /// </summary>
        /// <param name="percentVAT">VAT percentile value</param>
        /// <param name="priceBase">Price without VAT included</param>
        /// <returns>PriceModel instance with all VAT calculated values</returns>
        [HttpGet("CalcByPriceBase")]
        public ActionResult<PriceModel> CalcByPriceBase(
            [FromQuery, PositiveDecimal(ErrorMessage = "VAT percentile must be a number greater than zero")]
            decimal percentVAT,

            [FromQuery, PositiveDecimal(ErrorMessage = "Base price must be a number greater than zero")]
            decimal priceBase)
        {
            var priceItem = _priceCalculatorRepository.CalcByPriceBase(percentVAT, priceBase);

            return Ok(priceItem);
        }

        /// <summary>
        /// Calculate base price and price total from VAT amount and VAT percentile
        /// </summary>
        /// <param name="percentVAT">VAT percentile value</param>
        /// <param name="vatAmount">VAT monetary amount value</param>
        /// <returns>PriceModel instance with all VAT calculated values</returns>
        [HttpGet("CalcByVatAmount")]
        public ActionResult<PriceModel> CalcByVatAmount(
            [FromQuery, PositiveDecimal(ErrorMessage = "VAT percentile must be a number greater than zero")]
            decimal percentVAT,

            [FromQuery, PositiveDecimal(ErrorMessage = "VAT amount must be a number greater than zero")]
            decimal vatAmount)
        {
            var priceItem = _priceCalculatorRepository.CalcByVatAmount(percentVAT, vatAmount);

            return Ok(priceItem);
        }

        /// <summary>
        /// Calculate base price and VAT amount from price total and VAT percentile
        /// </summary>
        /// <param name="percentVAT">VAT percentile value</param>
        /// <param name="total">Price with VAT included</param>
        /// <returns>PriceModel instance with all VAT calculated values</returns>
        [HttpGet("CalcByTotal")]
        public ActionResult<PriceModel> CalcByTotal(
            [FromQuery, PositiveDecimal(ErrorMessage = "VAT percentile must be a number greater than zero")]
            decimal percentVAT,

            [FromQuery, PositiveDecimal(ErrorMessage = "Price total must be a number greater than zero")]
            decimal total)
        {
            var priceItem = _priceCalculatorRepository.CalcByTotal(percentVAT, total);

            return Ok(priceItem);
        }
    }
}
