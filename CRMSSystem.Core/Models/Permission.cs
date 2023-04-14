using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.Models
{
    public class Permission : BaseEntity
    {
        [Required]
        public bool View { get; set; }
        [Required]
        public bool Insert { get; set; }
        [Required]
        public bool Update { get; set; }
        [Required]
        public bool Delete { get; set; }
        [Required]
        public Guid? RoleId { get; set; }
        [Required]
        public Guid? FormId { get; set; }
    }
}
