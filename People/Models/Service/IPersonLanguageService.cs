using People.Models.PersonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.Service
{
   public interface IPersonLanguageService
    {

        public PersonLanguage Create(PersonLanguage personLanguage);

        public List<PersonLanguage> All();

        public PersonLanguage FindBy(int persId, int langId);

        public bool Remove(int persId, int langId);
    }
}
