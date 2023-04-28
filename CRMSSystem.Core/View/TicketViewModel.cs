using CRMSSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.View
{
    public class TicketViewModel :BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public Guid AssignToId { get; set; }
        [Required]
        public Guid TypeId { get; set; }
        [Required]
        public Guid PriorityId { get; set; }
        [Required]
        public Guid StatusId { get; set; }
        [Required]
        public string AssignTo { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Priority { get; set; }
        [Required]
        public string Status { get; set; }
        public string Image { get; set; }
        public List<DropDown> AssignDropDown { get; set; }
        public List<DropDown> PriorityDropDown { get; set; }

        public List<DropDown> StatusDropDown { get; set; }
        public List<DropDown> TypeDropDown { get; set; }
    }
   
}
