using ApplicationDomainModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApplicationDomainModels
{
    public class PhoneNumber : BaseEntity
    {
        public NumberType Type { get; set; }
        [MaxLength(50, ErrorMessage = "Name must be 2 characters or less"), MinLength(2, ErrorMessage = "Name must be 2 characters or more")]
        public string Number { get; set; }
        public int? PersonId { get; set; }
        [ForeignKey("PersonId")]
        public Person Person { get; set; }
    }
}
