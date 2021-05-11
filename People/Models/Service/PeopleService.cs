using People.Models.MetaData;
using People.Models.PersonData;
using People.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.Service
{
    
    public class PeopleService : IPeopelService
    {
        IPeopleRepo _personRepo; //Storage for person data
        public PeopleService(IPeopleRepo peopleRepo)
        {
            _personRepo = peopleRepo;

        }
        IPeopleRepo peopleRepo = new InMemoryPeopleRepo();
        public Person Add(CreatePerson createPerson)
        {
            Person person = new Person();
            person.FirstName = createPerson.FirstName;
            person.LastName = createPerson.LastName;
            person.City     =  createPerson.City;
            person.PhoneNumber = createPerson.PhoneNumber;
            //person.ACityId = createPerson.CityId;
            person = _personRepo.Create(createPerson);
            
            return person;


        }

        public PeopleViewModel All()
        {
            PeopleViewModel VM = new PeopleViewModel();
            VM.PersonL = _personRepo.Read();
            return VM;
        }
         public Person FindById(int id)
        {
            return _personRepo.Read(id);
        }

        public Person Edit(int id, Person person)
        {
            Person OrgP = FindById(id);
            if (OrgP == null)
            {
                return null;
            }
             OrgP.Id = person.Id;
            OrgP.FirstName = person.FirstName;
            OrgP.LastName = person.LastName;
            OrgP.City = person.City;
            OrgP.PhoneNumber = person.PhoneNumber;

            _personRepo.Update(OrgP);

            return OrgP;
        }
    

        public PeopleViewModel FindBy(PeopleViewModel search) //Look efter if is logic
        {
            List<Person> PersonfilterL = new List<Person>();//tom filterade listan
            foreach (Person item in _personRepo.Read())
            {
                if (item.FirstName.Equals(search.SearchFilter)|| // eller tac
                    item.LastName.Equals(search.SearchFilter) ||
                    item.City.Equals(search.SearchFilter))
                {
                    PersonfilterL.Add(item); //varje som machar den läggs filtareradelistan
                }
            }
            search.PersonL = PersonfilterL; //Tildelat filtarerade listan
            return search;
         

        }

        public bool Remove( int id)
        {
           return _personRepo.Delete( FindById(id));
           

        }
        

      
    }


}
