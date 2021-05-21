
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.ViewModel
{
    public class UserRegisterViewModel
    {
        [Required]
        [Display(Name = "User name")]
        [StringLength(30, MinimumLength = 3)]
       
        public string UserName { get; set; }
        [Required]
        [Display(Name = "First Name")]
        [StringLength(30, MinimumLength = 3)]
        public string FirstName { get;  set; }
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(30, MinimumLength = 3)]
        public string LastName { get;  set; }
        [Required]
        [EmailAddress]
        [StringLength(30, MinimumLength = 4)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        
        public DateTime BirthDate { get; set; }
        [Phone]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(40, MinimumLength = 6)]
        public string Password { get; set; }


        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
      
    }

}
