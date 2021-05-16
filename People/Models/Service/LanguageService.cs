using People.Models.MetaData;
using People.Models.PersonData;
using People.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.Service
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepo _languageRepo;
        private readonly IPersonLanguageRepo _personLanguageRepo;

       
        public LanguageService(ILanguageRepo iLanguageRepo, IPersonLanguageRepo personLanguageRepo)
        {
            _languageRepo = iLanguageRepo;
            _personLanguageRepo = personLanguageRepo;
        }

        public Language Add(CreateLanguageViewModel language)
        {
            Language ilanguage = new Language()
            {
                Name = language.Name
            };
            return _languageRepo.Create(ilanguage);

        }

        public List<Language> All()
        {
            return _languageRepo.Read();

        }

        public Language Edit(int id, EditLanguageViewModel mvlanguage)
        {
            Language ORGLanguage = FindById(id);

            if (ORGLanguage == null)
            {
                return null;
            }

            ORGLanguage.Name = mvlanguage.CreateViewmodel.Name;
            ORGLanguage = _languageRepo.Update(ORGLanguage);

            return ORGLanguage;
        }

        public Language FindById(int id)
        {
            return _languageRepo.Read(id);
        }

        public List<Person> FindLanguageSpeakersById(int id)
        {
            List<PersonLanguage> personLanguages = _personLanguageRepo.Read();
            List<Person> Lgspeakers = new List<Person>();
            foreach (var language in personLanguages)
            {
                if (language.LanguageId == id)
                {
                    Lgspeakers.Add(language.Person);
                }
            }
            return Lgspeakers;
        }

        public bool Remove(int id)
        {
            Language remoLanguage = _languageRepo.Read(id);
            if (remoLanguage != null)
            {
                return _languageRepo.Delete(remoLanguage);
            }
            return false;
        }
    }
    }

