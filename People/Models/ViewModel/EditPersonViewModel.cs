using People.Models.PersonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.ViewModel
{
    public class EditPersonViewModel
    {
        private CreatePerson personedit;

        public int Id { get; set; }

        public Person Person { get; set; }

        public CreatePerson CreatePerson { get; set; }
        public List<City> ListofCity { get; set; }
        public EditPersonViewModel(int id, Person person)
        {
            Id = id;
            this.Person = person;
            this.CreatePerson = new CreatePerson()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                CityId = person.InCityId,
                PhoneNumber = person.PhoneNumber,
            };
        }
            public EditPersonViewModel (int id, EditPersonViewModel personedit)
            {

            }

        public EditPersonViewModel(int id, CreatePerson personedit)
        {
            Id = id;
            this.personedit = personedit;
        }
    }
    } 

