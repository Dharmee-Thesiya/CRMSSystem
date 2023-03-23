using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.View
{
    public class ConferenceRoomViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Capacity { get; set; }
        public Guid? Id { get; set; }
    }
}
