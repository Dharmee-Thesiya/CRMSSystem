using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.Contracts
{
    public interface ITicketService
    {
        
        Ticket CreateTicket(TicketViewModel model);       
        List<DropDown> SetDropDownValues(string configName);
        List<TicketViewModel> GetTicket();
        TicketViewModel GetTickets(Guid Id);
        Ticket EditTicket(TicketViewModel model, string deleteAttachmentIds);
        Ticket DeleteTicket(Guid Id);
        TicketComment CommentTicket(TicketCommentViewModel model);
        List<TicketCommentViewModel> GetCommentList(Guid Id);
        TicketCommentViewModel UpdateComment(Guid Id);
        TicketComment DeleteComment(TicketCommentViewModel model);
        void EditComment(TicketCommentViewModel model);
        List<TicketViewModel> GetHistoryList(Guid Id);  
    }
}
