using People.Models.PersonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.ViewModel
{
    public class EditCountryViewModel
    {
        public int Id { get; set; }

        public CreateCountryViewModel Createveiwmodelforcntr { get; set; }


        public EditCountryViewModel(int id, Country country)
        {
               Id = id;
            this.Createveiwmodelforcntr = new CreateCountryViewModel()
            {
                Name = country.Name,
                CityList = country.Towns
            };
        }

        public EditCountryViewModel()
        {

        }


    }
}
