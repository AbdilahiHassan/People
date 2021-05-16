using People.DataBase;
using People.Models.PersonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.MetaData
{
    public class DBLanguageRepo : ILanguageRepo
    {
        //DBconnection
        private readonly PeopleDbContext _peopleDbContext;
        public DBLanguageRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }
        public Language Create(Language language)
        {
            _peopleDbContext.Add(language);
            if (_peopleDbContext.SaveChanges() > 0)
            {
                return language;
            }
            return null;
            {

            }
        }

        public bool Delete(Language language)
        {
            if (language == null)
            {
                return false;
            }
            else
            {
                Language origLanguage = Read(language.Id);
                if (origLanguage == null)
                {
                    return false;
                }

                _peopleDbContext.Remove(origLanguage);
                int Result = _peopleDbContext.SaveChanges();

                if (Result == 0)
                {
                    return false;
                }
                return true;
            }
        }
    
    

        public List<Language> Read()
        {
            return _peopleDbContext.Language.ToList();
        }

        public Language Read(int id)
        {return _peopleDbContext.Language.SingleOrDefault(x => x.Id == id);
         
        }

        public Language Update(Language language)
        {
            Language originallanguage = Read(language.Id);

            if (originallanguage == null)
            {
                return null;
            }

            _peopleDbContext.Update(language);

            int result = _peopleDbContext.SaveChanges();

            if (result == 0)
            {
                return null;
            }

            return originallanguage;
        }
    }
    }

