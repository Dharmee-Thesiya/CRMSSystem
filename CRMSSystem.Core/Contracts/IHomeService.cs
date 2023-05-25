using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.Contracts
{
    public interface IHomeService
    {
        int TotalTickets();
        int NewTickets();
        int AssignedTickets();
        int PendingTickets();
    }
}
