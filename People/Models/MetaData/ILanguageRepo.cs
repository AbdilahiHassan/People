using People.Models.PersonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.MetaData
{
  public  interface ILanguageRepo
    {

        public Language Create(Language language); 

        public List<Language> Read();

        public Language Read(int id); //FindById

        public Language Update(Language language);


        public bool Delete(Language language);
    }
}
