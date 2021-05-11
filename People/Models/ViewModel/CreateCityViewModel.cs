using People.Models.PersonData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.ViewModel
{
    public class CreateCityViewModel
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "CityName")]

        public string cityName { get; set; }

        [Required]
        [Display(Name = "Country")]
        public int NationsId { get; set; }
        public List<Country> Countries { get; set; }
        public List<City> CityList { get; set; }
    }
}
