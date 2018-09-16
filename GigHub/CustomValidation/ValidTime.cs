using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.CustomValidation
{
    public class ValidTime : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var date = value as string;
            var isValid = DateTime.TryParseExact(date,
                "HH:mm",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out DateTime _date);
            return (isValid);
        }
    }
}
