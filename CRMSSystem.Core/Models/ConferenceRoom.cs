using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.Models
{
    public class ConferenceRoom : BaseEntity
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
    }
}
