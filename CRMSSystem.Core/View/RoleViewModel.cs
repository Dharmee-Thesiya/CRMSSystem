using CRMSSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.View
{
    public class RoleViewModel : BaseEntity
    { 
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        //public Guid? Id { get; set; }
  
    }
}
