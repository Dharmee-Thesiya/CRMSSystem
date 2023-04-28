using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.SQL
{
    public class TicketRepository:ITicketRepository
    {
        internal DataContext context;
        internal DbSet<Ticket> DbSet;

        public TicketRepository(DataContext context)
        {
            this.context = context;
            this.DbSet = context.Set<Ticket>();
        }
        public IQueryable<Ticket> Collection()
        {
            return DbSet;
        }
        public void Commit()
        {
            context.SaveChanges();
        }

        public Ticket Find(Guid Id)
        {
            return DbSet.Find(Id);
        }

        public List<TicketViewModel> GetTicket()
        {
            var ticket = (from t in context.Ticket
                          join c in context.Ticket on t.Id equals c.Id
                          join u in context.User on t.Id equals u.Id
                          where !u.IsDeleted && !t.IsDeleted && !c.IsDeleted
                          select new TicketViewModel
                          {
                              Id = t.Id,
                              AssignToId = t.AssignTo,
                              PriorityId = t.PriorityId,
                              TypeId = t.TypeId,
                              StatusId = t.StatusId,
                              Title=t.Title,
                              Description=t.Description
                          }).ToList();
            return ticket;
        }
        public void Insert(Ticket ticket)
        {
            DbSet.Add(ticket);
        }

        TicketViewModel ITicketRepository.GetTicketById(Guid Id)
        {
            var ticket = (from t in context.Ticket
                          join c in context.Ticket on t.Id equals c.Id
                          join u in context.User on t.Id equals u.Id
                          where !t.IsDeleted && !c.IsDeleted && t.Id == Id
                          select new TicketViewModel
                          {
                              Id = t.Id,
                              AssignToId = t.AssignTo,
                              PriorityId = t.PriorityId,
                              TypeId = t.TypeId,
                              StatusId = t.StatusId,
                              Title = t.Title,
                              Description = t.Description
                          }).FirstOrDefault();
            return ticket;
        }
    }
}
