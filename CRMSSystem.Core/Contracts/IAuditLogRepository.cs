using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
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
        AuditLog Find(Guid Id);
        void Insert(AuditLog auditLog);
        List<AuditLogViewModel> GetAuditLogList(bool IsException);
        AuditLogViewModel GetAuditLogById(Guid Id);
    }
}
