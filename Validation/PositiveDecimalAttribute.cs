using System.ComponentModel.DataAnnotations;

namespace VATCalculator.Validation
{
    public class PositiveDecimalAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is decimal decimalValue)
            {
                return decimalValue > 0;
            }

            return false;
        }
    }
}
