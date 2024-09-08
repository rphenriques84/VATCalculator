
using VATCalculator.Helpers;
using VATCalculator.Models;
using VATCalculator.Repositories.Interfaces;

namespace VATCalculator.Repositories
{
    public class PriceCalculatorRepository : IPriceCalculatorRepository
    {
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
