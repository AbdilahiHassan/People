using People.Models.PersonData;
using People.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.Service
{
  public  interface ICityService
    {

        public City Add(CreateCityViewModel createCity);

        public CityViewModel All();

        public City FindBy(int id);
        public List<City> FindTownresident(int id);

        public City Edit(int id, EditCityViewModel city);

        public bool Remove(int id);
    }
}
