using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.PersonData
{
    public class PersonLanguage //JoinTable

    {

        public int  PersonId { get; set; }
        public Person Person { get; set; }
        public int LanguageId { get; set; }
        public Language language { get; set; }
    }

}
