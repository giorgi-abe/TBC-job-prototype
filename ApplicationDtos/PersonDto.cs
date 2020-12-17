using ApplicationDomainModels.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDtos
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public GenderType Gender { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CityId { get; set; }
        public List<PhoneNumberDto> Numbers { get; set; }
        public string Image { get; set; }
        public List<ConnectedPersonDto> ConnectedPeople { get; set; }
    }
}
