using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.SQL
{
    public class AuditLogRepository : IAuditLogRepository
    {
        internal DataContext context;
        internal DbSet<AuditLog> DbSet;
        public AuditLogRepository(DataContext context)
        {
            this.context = context;
            this.DbSet = context.Set<AuditLog>();
        }
        public IQueryable<AuditLog> Collection()
        {
            return DbSet;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(Guid Id)
        {
            var auditlog = Find(Id);

            if (context.Entry(auditlog).State == EntityState.Detached)
                DbSet.Attach(auditlog);
            DbSet.Remove(auditlog);
        }

        public AuditLog Find(Guid Id)
        {
            return DbSet.Find(Id);
        }

        public void Insert(AuditLog auditLog)
        {
            DbSet.Add(auditLog);
        }

        public void Update(AuditLog auditLog)
        {
            DbSet.Attach(auditLog);
            context.Entry(auditLog).State = EntityState.Modified;
        }
    }
}
