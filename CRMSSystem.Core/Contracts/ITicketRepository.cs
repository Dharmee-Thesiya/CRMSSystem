using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.Contracts
{
    public interface ITicketRepository
    {
        IQueryable<Ticket> Collection();
        void Commit();
        void Delete(Guid Id);
        Ticket Find(Guid Id);
        void Insert(Ticket ticket);
        void Update(Ticket ticket);
        List<TicketViewModel> GetTicket();
        TicketViewModel GetTicketById(Guid Id);
        List<TicketCommentViewModel> GetComments(Guid Id);
        TicketCommentViewModel GetCommentById(Guid Id);
        List<HomeViewModel> GetAllCount();
        List<TicketViewModel> GetHistoryList(Guid Id);
        List<TypecountTicket> TypeCount();
    }
}
