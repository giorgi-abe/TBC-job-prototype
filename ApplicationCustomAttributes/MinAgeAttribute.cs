using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCustomAttributes
{
    public class MinAgeAttribute : ValidationAttribute
    {
        public int MinAge { get; set; }

        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            var val = (DateTime)value;

            if (Convert.ToDateTime(DateTime.Now.Subtract(val)).Year > MinAge)
                return true;
            else
                return false;
        }
    }
}
