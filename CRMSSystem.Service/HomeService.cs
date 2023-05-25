using CRMSSystem.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Service
{
    public class HomeService : IHomeService
    {
        ITicketService _ticketService;
        public HomeService(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        public int TotalTickets()
        {
            return _ticketService.GetTicket().Count();
        }
        public int NewTickets()
        {
            return _ticketService.GetTicket().Where(x => x.Status == "New").Count();
        }
        public int AssignedTickets()
        {
            return _ticketService.GetTicket().Where(x => x.Status == "Assigned").Count();
        }
        public int PendingTickets()
        {
            return _ticketService.GetTicket().Where(x => x.Status == "Pending").Count();
        }
    }
}
