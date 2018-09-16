using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.CustomValidation
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var date = value as string;
            var isValid = DateTime.TryParseExact(date,
                "d MMM yyyy",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out DateTime _date);
            return (isValid && _date > DateTime.Now);
        }
    }
}
