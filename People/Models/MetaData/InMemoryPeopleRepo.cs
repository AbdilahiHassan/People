using People.Models.PersonData;
using People.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace People.Models.MetaData
{

    public class InMemoryPeopleRepo : IPeopleRepo
    {
     
        //static int idcounter = 0;
     List<Person> PersonList = new List<Person>();
         int IdCounter;

        public Person Create(CreatePerson createPerson)
        {
            Person newperson = new Person
            {
                Id = ++IdCounter,
                FirstName = createPerson.FirstName,
                LastName = createPerson.LastName,
                City = createPerson.City,
                PhoneNumber = createPerson.PhoneNumber

            };
            PersonList.Add(newperson);
            return newperson;

        }

        public bool Delete(Person person)
        {
            try
            {
                PersonList.Remove(person);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
         
        }

      

        public List<Person> Read()
        {
            return PersonList;
        }

        public Person Read(int id)
        {
            foreach (Person item in PersonList)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public Person Update(Person person)
        {
            Person orignalPerson = Read(person.Id);
            if(orignalPerson == null)
            {
                return null;
            }
            orignalPerson.FirstName = person.FirstName;
            orignalPerson.LastName = person.LastName;
            orignalPerson.City = person.City;
            orignalPerson.PhoneNumber = person.PhoneNumber;
            return orignalPerson;
        }
        
    }
}
