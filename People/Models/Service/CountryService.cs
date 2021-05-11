using People.Models.MetaData;
using People.Models.PersonData;
using People.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.Service
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepo _countryRepo; //data storage


        public CountryService(ICountryRepo countryRepo)
        {
      this._countryRepo = countryRepo;

        }
        public Country Add(CreateCountryViewModel createCountry)
        {
            Country country = new Country();
            country.Name = createCountry.Name;
            country.Towns = createCountry.CityList;
            return _countryRepo.Create(country);

        }

        public void Add(CountryViewModel createCountry)
        {
            throw new NotImplementedException();
        }

        public CountryViewModel All()
        {
            CountryViewModel countryViewModel = new CountryViewModel();
            countryViewModel.Nations = _countryRepo.Read();
            return countryViewModel;
        }

        public Country Edit(int id, EditCountryViewModel countryvmodel)
        {
           Country OriginalCountry = FindBy(id);

            if (OriginalCountry == null)
            {
                return null;
            }

            OriginalCountry.Name = countryvmodel.Createveiwmodelforcntr.Name;
            OriginalCountry.Towns = countryvmodel.Createveiwmodelforcntr.CityList;
            

            return _countryRepo.Update(OriginalCountry);
        }

        public Country FindBy(int id)
        {
            return _countryRepo.Read(id);
        }

        public bool Remove(int id)
        {
            Country DeleteCountry = _countryRepo.Read(id);//
            if (DeleteCountry != null)
            {
                return _countryRepo.Delete(DeleteCountry);
            }
            return false;
        }
    }
}
