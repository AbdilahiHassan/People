using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Models.ViewModel
{
    public class RolesManagmentViewModel
    {
        public String UserId { get; set; }
        public IList<String> UserRoles { get; set; }
        public List<IdentityRole> IdentityRole { get; set; }

        public RolesManagmentViewModel( string userId,IList<String> userRoles, List<IdentityRole> identityRole)
        {
            UserId = userId;
            UserRoles = userRoles;
            IdentityRole = identityRole;
            FilterRoles();

        }
        void FilterRoles()
        {
            foreach (string item in UserRoles)
            {
                IdentityRole.Remove(IdentityRole.Single(r => r.Name.Equals(item)));
            }

        }


    }
}
