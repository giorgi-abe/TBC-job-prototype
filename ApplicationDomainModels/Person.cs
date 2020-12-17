using ApplicationCustomAttributes;
using ApplicationDomainModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationDomainModels
{
    public class Person : BaseEntity
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name must be 2 characters or less"), MinLength(2, ErrorMessage = "Name must be 2 characters or more")]
        [SymbolsValidation]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(50, ErrorMessage = "Surname must be 2 characters or less"), MinLength(2, ErrorMessage = "Surname must be 2 characters or more")]
        [SymbolsValidation]
        public string Surname { get; set; }
        public GenderType Gender { get; set; }
        [Required]
        [SymbolsValidation]
        [StringLength(11, ErrorMessage = "IdentityNumber must be 11 characters")]
        public string IdentityNumber { get; set; }
        [Required]
        [MinAge]
        public DateTime DateOfBirth {get; set; }
        public int CityId { get; set; }
        public List<PhoneNumber> Numbers { get; set; }
        public string Image { get; set; }
        public List<ConnectedPerson> ConnectedPeople { get; set; }

    }
}
