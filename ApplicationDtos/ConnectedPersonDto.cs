using ApplicationDomainModels.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDtos
{
    public class ConnectedPersonDto
    {
        public int Id { get; set; }
        public ConnectType Type { get; set; }
        public int? PersonId { get; set; }
    }
}
