namespace VATCalculator.Helpers
{
    /// <summary>
    /// Helper class for VAT related calculations and business logic
    /// </summary>
    public static class HelperVAT
    {
        /// <summary>
        /// Calculate VAT rate from percentage
        /// </summary>
        /// <param name="percentVAT">VAT percentage value</param>
        /// <returns></returns>
        public static decimal CalcVATRate(decimal percentVAT) => percentVAT / 100;
        /// <summary>
        /// Truncate a decimal value to a specified number of decimal places (default 2)
        /// </summary>
        /// <param name="value">decimal value to be truncated</param>
        /// <param name="decimalPlaces">number of decimals places to truncate (default 2)</param>
        /// <returns></returns>
        public static decimal TruncateDecimal(decimal value, int decimalPlaces = 2)
        {
            decimal factor = (decimal)Math.Pow(10, decimalPlaces);
            
            return Math.Truncate(value * factor) / factor;
        }
    }
}
