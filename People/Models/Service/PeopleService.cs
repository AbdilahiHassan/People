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
        private readonly ILanguageRepo _languageRepo;
        private readonly IPersonLanguageRepo _personLanguageRepo;
        //t
        public PeopleService(IPeopleRepo peopleRepo, IPersonLanguageRepo personLanguageRepo, ILanguageRepo languageRepo)

        {
            _personRepo = peopleRepo;
            _personLanguageRepo = personLanguageRepo;
            _languageRepo = languageRepo;

        }

        public Person Add(CreatePerson createPerson)
        {
            if (createPerson.CityId == 0)
            {
                createPerson.CityId = null;
            }
            Person createdPerson = _personRepo.Create(createPerson);
            return createdPerson;
        }
        //IPeopleRepo peopleRepo = new InMemoryPeopleRepo();

        //public Person Add(CreatePerson createPerson)
        //{
        //    Person person = new Person();
        //    person.FirstName = createPerson.FirstName;
        //    person.LastName = createPerson.LastName;
        //    person.InCityId     =  createPerson.CityId;
        //    person.PhoneNumber = createPerson.PhoneNumber;
        //    //person.ACityId = createPerson.CityId;
        //    person = _personRepo.Create(createPerson);

        //    return person;


        //}

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

        public Person Edit(int id, EditPersonViewModel createPerson)
        {
            Person OrgP = FindById(id);
            if (OrgP == null)
            {
                return null;
            }
            OrgP.Id = createPerson.Id;
            OrgP.FirstName = createPerson.CreatePerson.FirstName;
            OrgP.LastName = createPerson.CreatePerson.LastName;
            OrgP.InCityId = createPerson.CreatePerson.CityId;
            OrgP.PhoneNumber = createPerson.CreatePerson.PhoneNumber;

            _personRepo.Update(OrgP);

            return OrgP;
        }


        public PeopleViewModel FindBy(PeopleViewModel search) //Look efter if is logic
        {
            List<Person> PersonfilterL = new List<Person>();//tom filterade listan
            foreach (Person item in _personRepo.Read())
            {
                if (item.FirstName.Equals(search.SearchFilter) || // eller tac
                    item.LastName.Equals(search.SearchFilter) ||
                    item.InCity.Equals(search.SearchFilter))
                {
                    PersonfilterL.Add(item); //varje som machar den läggs filtareradelistan
                }
            }
            search.PersonL = PersonfilterL; //Tildelat filtarerade listan
            return search;


        }

        public bool Remove(int id)
        {
            return _personRepo.Delete(FindById(id));


        }

    }
}
      



