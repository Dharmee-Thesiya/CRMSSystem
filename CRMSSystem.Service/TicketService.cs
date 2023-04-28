using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Service
{
    public class TicketService:ITicketService
    {
        ITicketRepository _ticketRepository;
        ICommonLookUpService _commonLookUpService;


        public TicketService(ITicketRepository ticketRepository, ICommonLookUpService commonLookUpService)
        {
            _ticketRepository = ticketRepository;
            _commonLookUpService = commonLookUpService;
        }
        public Ticket CreateTicket(TicketViewModel model)
        {
            Ticket ticket = new Ticket();
            ticket.Title = model.Title;
            ticket.StatusId = model.StatusId;
            ticket.PriorityId = model.PriorityId;
            ticket.TypeId = model.TypeId;
            ticket.AssignTo = model.AssignToId;
            ticket.Description = model.Description;         
            _ticketRepository.Insert(ticket);
            _ticketRepository.Commit();
            return ticket;
        }
        public List<DropDown> SetDropDownValues(string configName)
        {
            return _commonLookUpService.GetCommonLookUpByName(configName).Select(x => new DropDown { Id = x.Id, Name = x.ConfigKey }).ToList();
        }
       
        public List<TicketViewModel> GetTicket()
        {
            return _ticketRepository.GetTicket().OrderByDescending(x => x.CreatedOn).ToList();
        }

        public TicketViewModel GetTicketById(Guid Id)
        {
            return _ticketRepository.GetTicketById(Id);
        }
    }
    
}
