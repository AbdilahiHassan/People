using People.Models.PersonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace People.Models.ViewModel
{
    public class PeopleViewModel

    {

        public PeopleViewModel()
        {
            createPerson = new CreatePerson();
            PersonL = new List<Person>();
        } 

        public List<Person> PersonL { get; set; }

        public string SearchFilter { get; set; }

        public CreatePerson createPerson { get; set; }
    }

}

