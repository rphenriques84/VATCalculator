namespace VATCalculator.Helpers
{
    public static class HelperVAT
    {
        public static decimal CalcVATRate(decimal percentVAT) => percentVAT / 100;
        public static decimal TruncateDecimal(decimal value, int decimalPlaces = 2)
        {
            decimal factor = (decimal)Math.Pow(10, decimalPlaces);
            
            return Math.Truncate(value * factor) / factor;
        }
    }
}
