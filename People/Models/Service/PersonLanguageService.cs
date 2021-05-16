using People.Models.MetaData;
using People.Models.PersonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.Service
{
    public class PersonLanguageService : IPersonLanguageService
    {
        private readonly IPersonLanguageRepo _personLanguageRepo;
        public PersonLanguageService(IPersonLanguageRepo personLanguageRepo )
        {
            _personLanguageRepo = personLanguageRepo;
        }
        public List<PersonLanguage> All()
        {
            return _personLanguageRepo.Read();
        }

        public PersonLanguage Create(PersonLanguage personLanguage)
        {
            return _personLanguageRepo.Create(personLanguage);
        }

        public PersonLanguage FindBy(int persId, int langId)
        {
            return _personLanguageRepo.Read(persId, langId);
        }

        public bool Remove(int persId, int langId)
        {
            return _personLanguageRepo.Delete(persId, langId);
        }
    }
}
