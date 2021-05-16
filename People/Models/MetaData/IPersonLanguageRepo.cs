using People.Models.PersonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.MetaData
{
   public interface IPersonLanguageRepo
    {

        PersonLanguage Create(PersonLanguage personLanguage);

        PersonLanguage Read(int personId, int languageId);
        List<PersonLanguage> Read();

        bool Delete(int personId, int languageId);

    }
}
