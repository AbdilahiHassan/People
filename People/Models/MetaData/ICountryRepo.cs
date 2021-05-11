using People.Models.PersonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.MetaData
{
   public interface ICountryRepo
    {
        public Country Create(Country country);

        public List<Country> Read();

        public Country Read(int id);

        public Country Update(Country country);

        public bool Delete(Country country);
    }
}
