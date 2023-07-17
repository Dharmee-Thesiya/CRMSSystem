using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.View
{
    public class HomeViewModel
    {
        public int TicketCount { get; set; }
        public string AssignTo { get; set; }
    }
    public class TypecountTicket
    {
        public int TypeCount { get; set; }
        public string TypeName { get; set; }
    }
    public class StatusCountTicket
    {
        public int StatusCount { get; set; }
        public string StatusName { get; set; }

    }
}
