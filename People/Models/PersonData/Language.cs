using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.PersonData
{
    public class Language
    {
     //jag har tagit bort [key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        
        public string  Name { get; set; }
        //Many to Many join Table
        public List<PersonLanguage> PersonLanguages { get; set; }


    }
}
