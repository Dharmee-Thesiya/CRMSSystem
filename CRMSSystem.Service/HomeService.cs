using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.View;
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
        ITicketRepository _ticketRepository;
        public HomeService(ITicketService ticketService, ITicketRepository ticketRepository)
        {
            _ticketService = ticketService;
            _ticketRepository = ticketRepository;
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
        public List<HomeViewModel> GetAllCount()
        {
            return _ticketRepository.GetAllCount();
        }
        public List<TypecountTicket> GetTypecountTickets()
        {
            return _ticketRepository.TypeCount();
        }
        
    }
}
