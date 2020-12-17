using ApplicationDomainModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApplicationDomainModels
{
    public class ConnectedPerson : BaseEntity
    {
        public ConnectType Type { get; set; }
        public int? PersonId { get; set; }
        [ForeignKey("PersonId")]
        public Person Person { get; set; }
    }
}
