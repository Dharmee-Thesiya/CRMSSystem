using CRMSSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.View
{
    public class TicketCommentViewModel : BaseEntity
    {
        public Guid TicketId { get; set; }
        public string Comment { get; set; }
        public string CreatedbyName { get; set; }
        public string AssignTo { get; set; }
        public Guid AssignId { get; set; }
    }
}
