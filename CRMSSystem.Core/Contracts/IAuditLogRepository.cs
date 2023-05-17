using CRMSSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.Contracts
{
    public interface IAuditLogRepository
    {
        IQueryable<AuditLog> Collection();
        void Commit();
        void Delete(Guid Id);
        AuditLog Find(Guid Id);
        void Insert(AuditLog auditLog);
        void Update(AuditLog auditLog);
    }
}
