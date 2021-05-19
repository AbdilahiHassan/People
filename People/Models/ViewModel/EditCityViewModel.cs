using People.Models.PersonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.ViewModel
{
    public class EditCityViewModel
    {

        public int Id { get; set; }
       // public List<City> Citylist { get; set; }
        public CreateCityViewModel Createveiwmodel { get; set; }

    }
}
