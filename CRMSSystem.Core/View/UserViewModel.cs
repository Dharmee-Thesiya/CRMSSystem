        using CRMSSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.View
{
    public class UserViewModel : BaseEntity
    {
        [Required(ErrorMessage ="Name Is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Email Is Required")]
        [EmailAddress(ErrorMessage ="Please Enter Valid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Is Required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one special character, and be at least 8 characters long")]
        public string Password { get; set; }
        public string MobileNumber { get; set; }
        [Required(ErrorMessage = "UserName Is Required")]
        [StringLength(10,MinimumLength =6)] 
        public string UserName { get; set; }
        [Required(ErrorMessage = "Gender Is Required")]
        public string Gender { get; set; }
        //public Guid? Id { get; set; }
        [Required]
        public Guid RoleId { get; set; }

        [DisplayName("Role Name")]
        public string RoleName { get; set; }
        public List<DropDown> RoleDropDown { get; set; }
        
    }
    
}

