using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.Models
{
    public class UserRole : BaseEntity
    {
        
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        [ForeignKey("UserId")]
        public User UsersId { get; set; }
        [ForeignKey("RoleId")]
        public Role RolesId { get; set; }
    }
}
