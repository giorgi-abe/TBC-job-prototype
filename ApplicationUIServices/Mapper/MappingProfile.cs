using ApplicationDomainModels;
using ApplicationDtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationUIServices.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<PersonDto, Person>().ReverseMap();
            CreateMap<ConnectedPersonDto, ConnectedPerson>().ReverseMap();
            CreateMap<PhoneNumberDto, PhoneNumber>().ReverseMap();
        }
    }
}
