using People.Models.PersonData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.ViewModel
{
  
    public class CreatePerson
    {
        [Display(Name = "City")]
        public int? CityId { get; set; }
        //public string InCityId { get;  set; }
        [Required]
        public string FirstName { get;  set; }  
        [Required]
        public string LastName { get;  set; }
        [Required]
        public string PhoneNumber { get;  set; }

        public List<City> ListofCity { get; set; }
    }
}
