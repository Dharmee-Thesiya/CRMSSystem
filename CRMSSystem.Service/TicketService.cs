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
    public class TicketService : ITicketService
    {
        ITicketRepository _ticketRepository;
        ICommonLookUpService _commonLookUpService;
        IMRepository<TicketAttachment> _ticketAttachmentRepository;
        IMRepository<TicketComment> _ticketCommentRepository;

        public TicketService(ITicketRepository ticketRepository, ICommonLookUpService commonLookUpService, IMRepository<TicketAttachment> ticketAttachmentRepository, IMRepository<TicketComment> ticketCommentRepository)
        {
            _ticketRepository = ticketRepository;
            _commonLookUpService = commonLookUpService;
            _ticketAttachmentRepository = ticketAttachmentRepository;
            _ticketCommentRepository = ticketCommentRepository;
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
            ticket.CreatedBy = model.CreatedBy;
           

            _ticketRepository.Insert(ticket);
            _ticketRepository.Commit();

            if (model.Image != null)
            {
                TicketAttachment ticketAttachment = new TicketAttachment();
                {
                    ticketAttachment.TicketId = ticket.Id;
                    ticketAttachment.FileName = model.Image;
                    ticketAttachment.CreatedBy = model.CreatedBy;
                }
                _ticketAttachmentRepository.Insert(ticketAttachment);
                _ticketAttachmentRepository.Commit();
            }
            return ticket;
        }

        public List<TicketViewModel> GetTicket()
        {
            return _ticketRepository.GetTicket().OrderByDescending(x => x.CreatedOn).ToList();
        }

        public List<DropDown> SetDropDownValues(string configName)
        {
            return _commonLookUpService.GetCommonLookUpByName(configName).Select(x => new DropDown { Id = x.Id, Name = x.ConfigKey }).ToList();
        }
        public TicketViewModel GetTickets(Guid Id)
        {
            return _ticketRepository.GetTicketById(Id);
        }
        public Ticket EditTicket(TicketViewModel model, string deleteAttachmentIds)
        {
            Ticket ticket = _ticketRepository.Collection().Where(x => x.Id == model.Id).FirstOrDefault();
            ticket.Title = model.Title;
            ticket.StatusId = model.StatusId;
            ticket.PriorityId = model.PriorityId;
            ticket.TypeId = model.TypeId;
            ticket.AssignId = model.AssignId;
            ticket.Description = model.Description;
            ticket.Id = model.Id;
            ticket.UpdatedOn = DateTime.Now;
            _ticketRepository.Update(ticket);
            _ticketRepository.Commit();

            if (model.Image != null)
            {
                TicketAttachment ticketAttachment = new TicketAttachment();
                {
                    ticketAttachment.TicketId = ticket.Id;
                    ticketAttachment.Id = Guid.NewGuid();
                    ticketAttachment.FileName = model.Image;
                }
                _ticketAttachmentRepository.Insert(ticketAttachment);
                _ticketAttachmentRepository.Commit();
            }

            if (!string.IsNullOrEmpty(deleteAttachmentIds))
            {
                string[] ticketAttachments = deleteAttachmentIds.Split(',');

                if (ticketAttachments != null && ticketAttachments.Length > 0)
                {
                    foreach (var item in ticketAttachments)
                    {
                        var ticketToDelete = _ticketAttachmentRepository.Collection()
                                                .Where(x => x.Id.ToString() == item)
                                                .FirstOrDefault();

                        ticketToDelete.IsDeleted = true;
                        _ticketAttachmentRepository.Update(ticketToDelete);
                        _ticketAttachmentRepository.Commit();
                    }
                }
            }
           
            return ticket;
        }
        public Ticket DeleteTicket(Guid Id)
        {
            TicketViewModel model = new TicketViewModel();
            Ticket ticket = _ticketRepository.Collection().Where(x => x.Id == Id).FirstOrDefault();
            ticket.IsDeleted = true;
            _ticketRepository.Update(ticket);
            _ticketRepository.Commit();

            return ticket;
        }
        public TicketComment CommentTicket(TicketCommentViewModel model)
        {
            TicketComment ticketComment = new TicketComment();
            ticketComment.TicketId = model.TicketId;
            ticketComment.Comment = model.Comment;
            ticketComment.CreatedBy = model.CreatedBy;
            ticketComment.CreatedOn = DateTime.Now;
            _ticketCommentRepository.Insert(ticketComment); 
            _ticketCommentRepository.Commit();
            return ticketComment;
        }
        public List<TicketCommentViewModel> GetCommentList(Guid Id)
        {
            return _ticketRepository.GetComments(Id).OrderByDescending(x => x.CreatedOn).ToList();
        }
        public TicketCommentViewModel UpdateComment(Guid Id)
        {
            return _ticketRepository.GetCommentById(Id);
        }
        public TicketComment DeleteComment(TicketCommentViewModel model)
        {
            TicketComment ticketComment = _ticketCommentRepository.Collection().Where(x => x.Id == model.Id).FirstOrDefault();
            ticketComment.IsDeleted = true;
            _ticketCommentRepository.Update(ticketComment);
            _ticketCommentRepository.Commit();

            return ticketComment;
        }
        public void EditComment(TicketCommentViewModel model)
        {
            var ticketComment = _ticketCommentRepository.Collection().Where(x => x.Id == model.Id).FirstOrDefault();
            ticketComment.Comment = model.Comment;
            _ticketCommentRepository.Update(ticketComment);
            _ticketCommentRepository.Commit();
           
        }
    }
}
