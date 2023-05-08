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
    public class TicketRepository : ITicketRepository
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
                          where !t.IsDeleted 
                          orderby t.CreatedOn descending                     
                          select new TicketViewModel
                          {
                              Id = t.Id,
                              AssignId = u.Id,
                              TypeId = ct.Id,
                              StatusId = cs.Id,
                              PriorityId = cp.Id,
                              AssignTo = u.Name,
                              Type = ct.ConfigKey,
                              Status = cs.ConfigKey,
                              Priority = cp.ConfigKey,
                              Title = t.Title,
                              Description = t.Description
                          }).AsEnumerable();
                          
            var data = (from t in ticket
                        join ta in context.TicketAttachment on t.Id equals ta.TicketId into fdata
                        from taf in fdata.DefaultIfEmpty()
                        group taf by t into g
                        select new TicketViewModel
                        {
                            Id = g.Key.Id,
                            AssignId = g.Key.AssignId,
                            TypeId = g.Key.TypeId,
                            StatusId = g.Key.StatusId,
                            PriorityId = g.Key.PriorityId,
                            AssignTo = g.Key.AssignTo,
                            Type = g.Key.Type,
                            Status = g.Key.Status,
                            Priority = g.Key.Priority,
                            Title = g.Key.Title,
                            Description = g.Key.Description,
                            AttachmentList = g.Where(x => x!= null && x.FileName != null).Any() ? g.ToList() : null,
                            AttachmentCount = g.Where(x => x != null && x.FileName != null).Any() ? g.Count() : 0

                        }).ToList();
            return data;
        }
        public TicketViewModel GetTicketById(Guid Id)
        {
            var ticketedit = (from t in context.Ticket.Where(x => !x.IsDeleted).AsEnumerable()
                          join ct in context.CommonLookUps on t.TypeId equals ct.Id
                          join cs in context.CommonLookUps on t.StatusId equals cs.Id
                          join cp in context.CommonLookUps on t.PriorityId equals cp.Id
                          join u in context.User on t.AssignId equals u.Id
                          where !t.IsDeleted && t.Id == Id
                          orderby t.CreatedOn descending
                          select new TicketViewModel
                          {
                              Id = t.Id,
                              AssignTo = u.Name,
                              AssignId = u.Id,
                              TypeId = ct.Id,
                              StatusId = cs.Id,
                              PriorityId = cp.Id,
                              Type = ct.ConfigKey,
                              Status = cs.ConfigKey,
                              Priority = cp.ConfigKey,
                              Title = t.Title,
                              Description = t.Description,
                             
                          }).AsEnumerable();

            var edit = (from t in ticketedit
                        join ta in context.TicketAttachment on t.Id equals ta.TicketId into fdata
                        from taf in fdata.DefaultIfEmpty()
                        group taf by t into g
                        select new TicketViewModel
                        {
                            Id = g.Key.Id,
                            AssignId = g.Key.AssignId,
                            TypeId = g.Key.TypeId,
                            StatusId = g.Key.StatusId,
                            PriorityId = g.Key.PriorityId,
                            AssignTo = g.Key.AssignTo,
                            Type = g.Key.Type,
                            Status = g.Key.Status,
                            Priority = g.Key.Priority,
                            Title = g.Key.Title,
                            Description = g.Key.Description,
                            AttachmentList = g.Where(x => x != null && x.FileName != null).Any() ? g.ToList():null,
                            AttachmentCount = g.Where(x => x != null && x.FileName != null).Any() ? g.Count() : 0,
                        }).FirstOrDefault();
            return edit;

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

