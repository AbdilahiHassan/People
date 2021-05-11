using People.Models.MetaData;
using People.Models.PersonData;
using People.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.Service
{
    public class CityService : ICityService
    {
        readonly ICityRepo _cityRepo; //Storage for City data
        readonly ICountryRepo _countryRepo; //Storage for country data
        public CityService(ICityRepo cityRepo, ICountryRepo countryRepo)
        {
            this._cityRepo = cityRepo;
            this._countryRepo = countryRepo;
        }
        public City Add(CreateCityViewModel createCity)
        {
            City city = new City();

            city.CityName = createCity.cityName;
            city.CountryNationsName = _countryRepo.Read(createCity.NationsId);
          
            city = _cityRepo.Create(city);

            return city;

        }

        public CityViewModel All()
        {
            CityViewModel cityViewModel = new CityViewModel();
            cityViewModel.Towns = _cityRepo.Read();
            return cityViewModel;
        }

        public City Edit(int id, EditCityViewModel editcity)
        {
            City originalCity = FindBy(id);

            if (originalCity == null)
            {
                return null;
            }

            originalCity.CityName = editcity.Createveiwmodel.cityName;
            originalCity.CountryNationsName = _countryRepo.Read(editcity.Createveiwmodel.NationsId);
           

            originalCity = _cityRepo.Update(originalCity);

            return originalCity;
        }

        public City FindBy(int id)
        {
            return _cityRepo.Read(id);
        }

        public List<City> FindTownresident(int id)
        {
            List<City> TownresidentList = new List<City>();

            foreach (City item in _cityRepo.Read())
            {
                if (item.CountryNationsName.Equals(id))
                {
                    TownresidentList.Add(item);
                }
            }

            return TownresidentList;
        }

        public bool Remove(int id)
        {
            City city = _cityRepo.Read(id);
            if(city !=null)
            {
         return _cityRepo.Delete(city);
            }
            
            return false;
      
        }
    }
}
