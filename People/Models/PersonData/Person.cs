using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.PersonData
{

    public class Person
    {
        [Key]
        public int Id { get; set; }

        //[Required]
        //[MaxLength(60)]
        //public string Name { get; set; } //added

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(40)]
        public string PhoneNumber { get; set; }
        //[Required]
        //[MaxLength(70)]

        [ForeignKey("InCity")]
        public int? InCityId { get; set; }   
        public City InCity { get; set; }
       // public string City { get; set; }
    
        // public List<City> CityId { get; set; }
        public List<PersonLanguage> PersonLanguages { get; set; }


    }
}