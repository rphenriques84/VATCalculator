using VATCalculator.Models;
using System.Collections.Generic;

namespace VATCalculator.Repositories.Interfaces
{
    public interface IPriceCalculatorRepository
    {
        PriceModel CalcByPriceBase(decimal percentVAT, decimal priceBase);
        PriceModel CalcByVatAmount(decimal percentVAT, decimal vatAmount);
        PriceModel CalcByTotal(decimal percentVAT, decimal total);
    }
}
