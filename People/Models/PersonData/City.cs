using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.PersonData
{
    public class City
    {
    
       public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string CityName { get; set; }

        public List<Person> townresident{ get; set; }
        [Required]

        public Country CountryNationsName { get; set; }

    }
}
