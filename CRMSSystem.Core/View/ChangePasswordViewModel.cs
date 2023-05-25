using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.View
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "CurrentPassword Is Required")]
        public string CurrentPassword { get; set; }
        [Required(ErrorMessage = "NewPassword Is Required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one special character, and be at least 8 characters long")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "ConfirmPassword Is Required")]
        [Compare("NewPassword", ErrorMessage = "NewPassword and Confirmation Password must match")]
        public string ConfirmPassword { get; set; }
    }
}
