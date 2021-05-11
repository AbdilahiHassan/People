using People.DataBase;
using People.Models.PersonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.MetaData
{
    public class DataBaseCountryRepo : ICountryRepo
    {
        readonly PeopleDbContext _peopleDbContext; //Dependenciy injection
        public DataBaseCountryRepo(PeopleDbContext peopleDbContext)
        {
            this._peopleDbContext = peopleDbContext;
        }
        public Country Create(Country country)
        {
            _peopleDbContext.Countries.Add(country);

            int result = _peopleDbContext.SaveChanges();

            if (result == 0)//no changes in the database
            {
                throw new Exception("Unable to create country in database");
            }

            return country;
        }

        public bool Delete(Country country)
        {
            Country OrGcountry = Read(country.Id);
            if (OrGcountry == null)
            {
                return false;
            }

            _peopleDbContext.Remove(OrGcountry);
            int saveResult = _peopleDbContext.SaveChanges();

            if (saveResult == 0)//no changes in the database
            {
                return false;
            }
            return true;
        }

        public List<Country> Read()
        {
            return _peopleDbContext.Countries.ToList();
        }

        public Country Read(int id)
        {
         return _peopleDbContext.Countries.SingleOrDefault(country => country.Id ==id); 
        }

        public Country Update(Country country)
        {
            Country originalCountry = Read(country.Id);

            if (originalCountry == null)
            {
                return null;
            }

            _peopleDbContext.Update(country);

            int result = _peopleDbContext.SaveChanges();

            if (result == 0)
            {
                return null;
            }

            return originalCountry;
        }

    }
}

