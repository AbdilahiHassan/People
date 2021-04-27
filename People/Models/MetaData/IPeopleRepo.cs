using People.Models.PersonData;
using People.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.MetaData
{
   public interface IPeopleRepo
    {

        public Person Create(CreatePerson createPerson);

        public List<Person> Read();

        public Person Read(int id); //FindById

        public Person Update(Person person);


        public bool Delete(Person person);
       
    }
}
