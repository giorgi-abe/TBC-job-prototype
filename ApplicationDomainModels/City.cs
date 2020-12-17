using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationDomainModels
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
    }
}
