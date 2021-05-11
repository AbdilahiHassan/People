using People.Models.PersonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.ViewModel
{
    public class CityDetailsViewModel
    {

        public int Id { get; set; }

        public List<Person> townresident { get; set; }

        public string NationName { get; set; }

        public string CityName { get; set; }
    }
}
