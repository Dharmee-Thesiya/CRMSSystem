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
        
        public AuditLog Find(Guid Id)
        {
            return DbSet.Find(Id);
        }
        public void Insert(AuditLog auditLog)
        {
            DbSet.Add(auditLog);
        }
        
        public List<AuditLogViewModel> GetAuditLogList(bool IsException)
        {
            var audits = (from a in context.AuditLog                         
                          join u in context.User on a.UserId equals u.Id
                          where (IsException && a.Exception!= null) || (!IsException && a.Exception == null)
                          select new AuditLogViewModel
                          {
                              Id = a.Id,
                              UserId = u.Id,
                              ExecutionTime = a.ExecutionTime,
                              ExecutionDuration = a.ExecutionDuration,
                              ClientAddress = a.ClientAddress,
                              BrowserInfo = a.BrowserInfo,
                              HttpMethod = a.HttpMethod,
                              Url = a.Url,
                              UserName = u.UserName,
                              HttpStatusCode = a.HttpStatusCode,
                              Comments = a.Comments,
                              Parameters=a.Parameters,
                              Exception=a.Exception
                          }).ToList();
            return audits;
        }

        public AuditLogViewModel GetAuditLogById(Guid Id)
        {
            var audits = (from a in context.AuditLog.Where(x=>x.Parameters!=null)
                          join u in context.User on a.UserId equals u.Id
                          where a.Id==Id
                          select new AuditLogViewModel
                          {
                              Id = a.Id,
                              UserId = u.Id,
                              ExecutionTime = a.ExecutionTime,
                              ExecutionDuration = a.ExecutionDuration,
                              ClientAddress = a.ClientAddress,
                              BrowserInfo = a.BrowserInfo,
                              HttpMethod = a.HttpMethod,
                              Url = a.Url,
                              UserName = u.UserName,
                              HttpStatusCode = a.HttpStatusCode,
                              Comments = a.Comments,
                              Parameters=a.Parameters,
                              Exception=a.Exception
                          }).FirstOrDefault();
            return audits;
        }
    }
}
