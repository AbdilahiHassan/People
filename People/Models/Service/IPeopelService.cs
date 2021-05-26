using People.Models.PersonData;
using People.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.Service
{
    public interface IPeopelService
    {
        public Person Add(CreatePerson createPerson);

        public PeopleViewModel All();

        public PeopleViewModel FindBy(PeopleViewModel search);

        public Person FindById(int id);

        public Person Edit(int id, EditPersonViewModel createPerson);

        public bool Remove(int id);
      //  Person FindBy(int id);
    }
}
