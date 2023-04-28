
using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace CRMSSystem.SQL
{
    public class SQLRepository<T> : IMRepository<T> where T : BaseEntity
    {
        internal DataContext context;
        internal DbSet<T> DbSet;
        internal DbSet<CommonLookUp> commonLookUpDbSet;
        internal DbSet<TicketAttachment> ticketAttachmentDbSet;
       
        
        public SQLRepository(DataContext context)
        {
            this.context = context;
            this.DbSet = context.Set<T>();
            this.commonLookUpDbSet = context.Set<CommonLookUp>();
            this.ticketAttachmentDbSet = context.Set<TicketAttachment>();
            
        }

        public IQueryable<T> Collection()
        {
            return DbSet; 
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(Guid Id)
        {
            var t = Find(Id);
            if (context.Entry(t).State == EntityState.Detached)
            {
                DbSet.Attach(t);
            }
            DbSet.Remove(t);
        }

        public T Find(Guid Id)
        {
            return DbSet.Find(Id);
        }

        public void Insert(T t)
        {
            DbSet.Add(t);
        }

        public void Update(T t)
        {
            DbSet.Attach(t);
            context.Entry(t).State = EntityState.Modified;
        }
    }
}
