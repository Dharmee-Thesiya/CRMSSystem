using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.Models
{
    public class CommonLookUp : BaseEntity
    {
       public string ConfigName { get; set; }
       public string ConfigKey { get; set; }
       public string ConfigValue { get; set; }
       public int? DisplayOrder { get; set; }
       public string  Description { get; set; }
        [NotMapped ]
        public bool IsEdit { get; set; }
      
    }
}
