using People.DataBase;
using People.Models.PersonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.MetaData
{
    public class DBPersonLanguageRepo : IPersonLanguageRepo
    {
        //DBconnection
        private readonly PeopleDbContext _peopleDbContext;
        public DBPersonLanguageRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;

        }
        public PersonLanguage Create(PersonLanguage personLanguage)
        {
            _peopleDbContext.PersonLanguage.Add(personLanguage);
            if (_peopleDbContext.SaveChanges() > 0)
            {
                return personLanguage;
            }
            return null;
        }

        public bool Delete(int personId, int languageId)
        {
            PersonLanguage personlang = Read(personId, languageId);

            if (personlang == null)
            {
                return false;
            }

            _peopleDbContext.PersonLanguage.Remove(personlang);

            if (_peopleDbContext.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }

    

        public PersonLanguage Read(int personId, int languageId)
        {
            return _peopleDbContext.PersonLanguage.SingleOrDefault(pl => pl.PersonId == personId && pl.LanguageId == languageId);

        }

        public List<PersonLanguage> Read()
        {
            return _peopleDbContext.PersonLanguage.ToList();
        }
    }
}
