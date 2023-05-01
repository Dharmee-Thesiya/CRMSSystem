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

        public void Delete(Guid Id)
        {
            var ticket = Find(Id);

            if (context.Entry(ticket).State == EntityState.Detached)
                DbSet.Attach(ticket);
            DbSet.Remove(ticket);
        }

        public Ticket Find(Guid Id)
        {
            return DbSet.Find(Id);
        }

        public List<TicketViewModel> GetTicket()
        {
            //throw new NotImplementedException();
            var ticket = (from t in context.Ticket
                          join ct in context.CommonLookUps on t.TypeId equals ct.Id
                          join cs in context.CommonLookUps on t.StatusId equals cs.Id
                          join cp in context.CommonLookUps on t.PriorityId equals cp.Id
                          join u in context.User on t.AssignId equals u.Id
                          join ta in context.TicketAttachment on t.Id equals ta.TicketId
                          where !t.IsDeleted
                          orderby t.CreatedOn descending
                          select new TicketViewModel
                          { 
                                AssignTo=u.Name,
                                Type=ct.ConfigKey,
                                Status=cs.ConfigKey,
                                Priority=cp.ConfigKey,
                                Title=t.Title,
                                Description=t.Description,
                                Attachment= ta.FileName

                          }).ToList();
            return ticket;
        }

        public void Insert(Ticket ticket)
        {
            DbSet.Add(ticket);
        }

        public void Update(Ticket ticket)
        {
            DbSet.Attach(ticket);
            context.Entry(ticket).State = EntityState.Modified;
        }
    }
}

