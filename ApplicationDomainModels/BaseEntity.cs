using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationDomainModels
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
