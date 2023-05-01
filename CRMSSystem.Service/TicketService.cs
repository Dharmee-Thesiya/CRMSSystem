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
        IMRepository<TicketAttachment> _ticketAttachmentRepository;

        public TicketService(ITicketRepository ticketRepository, ICommonLookUpService commonLookUpService, IMRepository<TicketAttachment> ticketAttachmentRepository)
        {
            _ticketRepository = ticketRepository;
            _commonLookUpService = commonLookUpService;
            _ticketAttachmentRepository = ticketAttachmentRepository;
        }
        public Ticket CreateTicket(TicketViewModel model)
        {
            Ticket ticket = new Ticket();
            ticket.Title = model.Title;
            ticket.StatusId = model.StatusId;
            ticket.PriorityId = model.PriorityId;
            ticket.TypeId = model.TypeId;
            ticket.AssignId = model.AssignId;
            ticket.Description = model.Description;
            ticket.Id = model.Id; 

            _ticketRepository.Insert(ticket);
            _ticketRepository.Commit();

            TicketAttachment ticketAttachment = new TicketAttachment();
            {
                ticketAttachment.TicketId = ticket.Id;
                ticketAttachment.FileName = model.Image;
            }
            _ticketAttachmentRepository.Insert(ticketAttachment);
            _ticketAttachmentRepository.Commit();
            return ticket;
        }

        public List<TicketViewModel> GetTicket()
        {
            return _ticketRepository.GetTicket().OrderByDescending(x => x.CreatedOn).ToList(); ;
        }

        public List<DropDown> SetDropDownValues(string configName)
        {
            return _commonLookUpService.GetCommonLookUpByName(configName).Select(x => new DropDown { Id = x.Id, Name = x.ConfigKey }).ToList();
        } 
    } 
}
