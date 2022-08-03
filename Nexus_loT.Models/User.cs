using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus_loT.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        //[Required]
        //[Display(Name = "Role")]
        //public IdentityRole RoleId { get; set; }
        //[Display(Name = "Phone Number")]
        //public string PhoneNumber { get; set; }
        //public string Role { get; set; }
        //public IEnumerable<SelectListItem> RoleList { get; set; }
    }
}
