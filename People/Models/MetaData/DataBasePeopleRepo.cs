using People.Models.MetaData;
using People.Models.PersonData;
using People.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using People.DataBase;
using Microsoft.EntityFrameworkCore;

namespace People.Models.Repo
{
    public class DataBasePeopleRepo : IPeopleRepo
    {
        readonly PeopleDbContext _peopleDbContext; //Dependency injection

        public DataBasePeopleRepo(PeopleDbContext peopleDbContext)//Connection to the database
        {
            _peopleDbContext = peopleDbContext;
        }
        public Person Create(CreatePerson createPerson)
        {
            Person newperson = new Person
            {

                FirstName = createPerson.FirstName,
                LastName = createPerson.LastName,
                InCityId = createPerson.CityId,
                //  City = createPerson.City,
                PhoneNumber = createPerson.PhoneNumber,
         
            };
            _peopleDbContext.persons.Add(newperson);

            int Result = _peopleDbContext.SaveChanges();

            if (Result == 0)//no changes in the database
            {

                throw new Exception("unable to create person in database.");
            }

            return newperson;
        }



        public bool Delete(Person person)
        {
            Person originalPerson = Read(person.Id);

            if (originalPerson == null)
            {
                return false;
            }

            _peopleDbContext.persons.Remove(originalPerson);

            int result = _peopleDbContext.SaveChanges();

            if (result == 0)
            {
                return false;
            }

            return true;
        
    } 

        public List<Person> Read()

        {
         return _peopleDbContext.persons.Include("InCity").ToList();

           
        }

        public Person Read(int id)
        {
            //return _peopleDbContext.persons.Include(city => city.CityId).SingleOrDefault(row => row.Id == id);

            return _peopleDbContext.persons.SingleOrDefault(persontable => persontable.Id == id);//go to db,personTable/single/orDf/not found null
        }

        public Person Update(Person person)
        {
           Person originalPerson = Read(person.Id);

            if (originalPerson == null)
            {
                return null;
            }

           _peopleDbContext.Update(person);

            int result = _peopleDbContext.SaveChanges();

            if (result == 0)
            {
                return null;
            }

            return originalPerson;
        }
    }

    }

    

