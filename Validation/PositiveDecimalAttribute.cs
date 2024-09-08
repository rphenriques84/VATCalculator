
using System.ComponentModel.DataAnnotations;

namespace VATCalculator.Validation
{
    /// <summary>
    /// Validation atributte for monetary decimal values
    /// </summary>
    public class PositiveDecimalAttribute : ValidationAttribute
    {
        /// <summary>
        /// Validity check for positive, non-nullable decimal
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object? value)
        {
            if (value == null) return false;

            if (value is decimal decimalValue)
            {
                return decimalValue > 0;
            }

            return false;
        }
    }
}
