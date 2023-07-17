using CRMSSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.View
{
    public class TicketHistoryStatusViewModel:BaseEntity
    {
        public Guid TicketId { get; set; }
        public string OldStatus { get; set; }
        public string Newstatus { get; set; }
        public string CreatedbyName { get; set; }
    }
}
