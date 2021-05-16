using People.Models.PersonData;
using People.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.Service
{
  public  interface ILanguageService
    {
        Language Add(CreateLanguageViewModel language);

      List<Language> All();

        Language FindById(int id);
        List<Person> FindLanguageSpeakersById(int id);
        Language Edit(int id, EditLanguageViewModel language);

        bool Remove(int id);
    }
}
