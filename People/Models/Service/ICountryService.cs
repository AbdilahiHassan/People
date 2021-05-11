using People.Models.PersonData;
using People.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.Service
{
   public interface ICountryService
    {
        public Country Add(CreateCountryViewModel createCountry);

        public CountryViewModel All();

        public Country FindBy(int id);



        public Country Edit(int id, EditCountryViewModel country);

        public bool Remove(int id);
        void Add(CountryViewModel createCountry);
    }
}
