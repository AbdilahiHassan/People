using People.Models.PersonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.ViewModel
{
    public class EditLanguageViewModel
    {
        public int Id { get; set; }

        public CreateLanguageViewModel CreateViewmodel { get; set; }

        public List<Person> Speakers { get; set; }


        public EditLanguageViewModel(int id, Language language)
        {
            Id = id;
            this.CreateViewmodel = new CreateLanguageViewModel()
            {
                Name = language.Name,
            };
            Speakers = new List<Person>();
        }

        public EditLanguageViewModel()
        {
            Speakers = new List<Person>();
        }

    }
}
