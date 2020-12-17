using ApplicationDomainModels.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDtos
{
    public class PhoneNumberDto
    {
        public int Id { get; set; }
        public NumberType Type { get; set; }
        public string Number { get; set; }
    }
}
