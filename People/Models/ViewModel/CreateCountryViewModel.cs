using People.Models.PersonData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.ViewModel
{
    public class CreateCountryViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Country name")]
        public string Name { get; set; }


        public List<City> CityList { get; set; }

        public CreateCountryViewModel() //CreateCountryViewModel
        {
            CityList = new List<City>();
        }

    }
}
