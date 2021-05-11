using Microsoft.EntityFrameworkCore;
using People.DataBase;
using People.Models.PersonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.MetaData
{
    public class DataBaseCityRepo : ICityRepo
    {
        readonly PeopleDbContext _peopleDbContext; //Dependenciy injection
        public DataBaseCityRepo(PeopleDbContext peopleDbContext)
        {
           this._peopleDbContext = peopleDbContext;
        }
        public City Create(City city)
        {
            _peopleDbContext.Towns.Add(city);

            int result = _peopleDbContext.SaveChanges();

            if (result == 0)//no changes in the database
            {
                throw new Exception("Unable to create city in database");
            }

            return city;

        }
    

        public bool Delete(City city)
        {
         
                City OrGCity = Read(city.Id);
                if (OrGCity == null)
                {
                    return false;
                }

                _peopleDbContext.Remove(OrGCity);
                int saveResult = _peopleDbContext.SaveChanges();

                if (saveResult == 0)//no changes in the database
                {
                    return false;
                }
                return true;
            
        }

        public List<City> Read()
        {
            return _peopleDbContext.Towns.Include(city => city.CountryNationsName).ToList();
        }

        public City Read(int id)
        {
         return _peopleDbContext.Towns.Include(city=> city.CountryNationsName).SingleOrDefault(row => row.Id == id);//if not found it will return nul
        }

        public City Update(City city)
        {

            City originalCity = Read(city.Id);

            if (originalCity == null)
            {
                return null;
            }

            _peopleDbContext.Update(city);

            int result = _peopleDbContext.SaveChanges();

            if (result == 0)
            {
                return null;
            }

            return originalCity;
        }


    }
    }

