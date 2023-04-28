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

