using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.ViewModel
{
    public class CreateLanguageViewModel
    {
        [Required]
        [StringLength(80, MinimumLength = 3 )] //data från Languguage class
        public string Name { get; set; }
        public CreateLanguageViewModel() //model binding  controller needs a zero constructor to pressent
        {

        }
    }
}
