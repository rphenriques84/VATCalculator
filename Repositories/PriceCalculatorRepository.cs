
using VATCalculator.Helpers;
using VATCalculator.Models;
using VATCalculator.Repositories.Interfaces;

namespace VATCalculator.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class PriceCalculatorRepository : IPriceCalculatorRepository
    {
        /// <summary>
        /// Calculate VAT amount and price total from base price and VAT percentile
        /// </summary>
        /// <param name="percentVAT">VAT percentile value</param>
        /// <param name="priceBase">Price without VAT included</param>
        /// <returns>PriceModel instance with all VAT calculated values</returns>
        public PriceModel CalcByPriceBase(decimal percentVAT, decimal priceBase)
        {
            decimal vatRate = HelperVAT.CalcVATRate(percentVAT);
            decimal vatAmount = priceBase * vatRate;

            return new PriceModel()
            {
                PriceBase = priceBase,
                VatAmount = HelperVAT.TruncateDecimal(vatAmount),
                PriceTotal = HelperVAT.TruncateDecimal(priceBase + vatAmount)
            };
        }

        /// <summary>
        /// Calculate base price and price total from VAT amount and VAT percentile
        /// </summary>
        /// <param name="percentVAT">VAT percentile value</param>
        /// <param name="vatAmount">VAT monetary amount value</param>
        /// <returns>PriceModel instance with all VAT calculated values</returns>
        public PriceModel CalcByVatAmount(decimal percentVAT, decimal vatAmount)
        {
            decimal vatRate = HelperVAT.CalcVATRate(percentVAT);
            decimal priceBase = vatAmount / vatRate;

            return new PriceModel()
            {
                PriceBase = HelperVAT.TruncateDecimal(priceBase),
                VatAmount = vatAmount,
                PriceTotal = HelperVAT.TruncateDecimal(priceBase + vatAmount)
            };
        }

        /// <summary>
        /// Calculate base price and VAT amount from price total and VAT percentile
        /// </summary>
        /// <param name="percentVAT">VAT percentile value</param>
        /// <param name="total">Price with VAT included</param>
        /// <returns>PriceModel instance with all VAT calculated values</returns>
        public PriceModel CalcByTotal(decimal percentVAT, decimal total)
        {
            decimal vatRate = HelperVAT.CalcVATRate(percentVAT);
            decimal priceBase = total / (1 + vatRate);

            return new PriceModel()
            {
                PriceBase = HelperVAT.TruncateDecimal(priceBase),
                VatAmount = HelperVAT.TruncateDecimal(total - priceBase),
                PriceTotal = total
            };
        }
    }
}
