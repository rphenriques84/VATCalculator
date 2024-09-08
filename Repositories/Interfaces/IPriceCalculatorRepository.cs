using VATCalculator.Models;
using System.Collections.Generic;

namespace VATCalculator.Repositories.Interfaces
{
    /// <summary>
    /// Interface for PriceCalculatorRepository repo
    /// </summary>
    public interface IPriceCalculatorRepository
    {
        /// <summary>
        /// Calculate VAT amount and price total from base price and VAT percentile
        /// </summary>
        /// <param name="percentVAT">VAT percentile value</param>
        /// <param name="priceBase">Price without VAT included</param>
        /// <returns>PriceModel instance with all VAT calculated values</returns>
        PriceModel CalcByPriceBase(decimal percentVAT, decimal priceBase);
        /// <summary>
        /// Calculate base price and price total from VAT amount and VAT percentile
        /// </summary>
        /// <param name="percentVAT">VAT percentile value</param>
        /// <param name="vatAmount">VAT monetary amount value</param>
        /// <returns>PriceModel instance with all VAT calculated values</returns>
        PriceModel CalcByVatAmount(decimal percentVAT, decimal vatAmount);
        /// <summary>
        /// Calculate base price and VAT amount from price total and VAT percentile
        /// </summary>
        /// <param name="percentVAT">VAT percentile value</param>
        /// <param name="total">Price with VAT included</param>
        /// <returns>PriceModel instance with all VAT calculated values</returns>
        PriceModel CalcByTotal(decimal percentVAT, decimal total);
    }
}
