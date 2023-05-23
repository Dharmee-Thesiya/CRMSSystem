using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.Contracts
{
    public interface IAuditLogService
    {
        string CreateAuditLog(string exception, int statusCode);
        List<AuditLogViewModel> GetAuditLog(bool IsException = false);
        AuditLogViewModel GetAuditById(Guid Id);
    }
}
