using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.ComponentModel.DataAnnotations;
using VATCalculator.Models;
using VATCalculator.Repositories.Interfaces;
using VATCalculator.Validation;
//using System.Collections.Generic;

namespace VATCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly IPriceCalculatorRepository _priceCalculatorRepository;

        public PriceController(IPriceCalculatorRepository priceCalculatorRepository)
        {
            _priceCalculatorRepository = priceCalculatorRepository;
        }

        /// <summary>
        /// Calculate VAT amount and price total from base price and VAT percentile
        /// </summary>
        /// <param name="percentVAT">VAT percentile value</param>
        /// <param name="priceBase">Price without VAT included</param>
        /// <returns>test return CalcByPriceBase</returns>
        [HttpGet("CalcByPriceBase")]
        public ActionResult<PriceModel> CalcByPriceBase(
            [FromQuery, PositiveDecimalAttribute(ErrorMessage = "VAT percentile must be a number greater than zero")]
            decimal percentVAT,

            [FromQuery, PositiveDecimalAttribute(ErrorMessage = "Base price must be a number greater than zero")]
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
        /// <returns>test return CalcByVatAmount</returns>
        [HttpGet("CalcByVatAmount")]
        public ActionResult<PriceModel> CalcByVatAmount(
            [FromQuery, PositiveDecimalAttribute(ErrorMessage = "VAT percentile must be a number greater than zero")]
            decimal percentVAT,

            [FromQuery, PositiveDecimalAttribute(ErrorMessage = "VAT amount must be a number greater than zero")]
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
        /// <returns>test return CalcByTotal</returns>
        [HttpGet("CalcByTotal")]
        public ActionResult<PriceModel> CalcByTotal(
            [FromQuery, PositiveDecimalAttribute(ErrorMessage = "VAT percentile must be a number greater than zero")]
            decimal percentVAT,

            [FromQuery, PositiveDecimalAttribute(ErrorMessage = "Price total must be a number greater than zero")]
            decimal total)
        {
            var priceItem = _priceCalculatorRepository.CalcByTotal(percentVAT, total);

            return Ok(priceItem);
        }
    }
}
