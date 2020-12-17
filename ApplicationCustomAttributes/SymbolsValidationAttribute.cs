using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ApplicationCustomAttributes
{
    public class SymbolsValidationAttribute : ValidationAttribute
    {

        Regex latinRegex = new Regex("^[a-zA-Z]");
        string GeorgianSymbols = "ქწერტყუიოპკჯჰგფდსაზხცვბნმ";

        public override bool IsValid(object value)
        {

            var val = latinRegex.IsMatch(value.ToString());
            var val1 = value.ToString().Where(o => GeorgianSymbols.Any(s => s == o)).Count() == value.ToString().Length;

            if (val ^ val1)
                return true;
            else
                return false;
        }
    }
}
