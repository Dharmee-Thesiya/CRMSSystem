using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.Contracts
{
    public interface IPermissionRepository
    {
        IQueryable<Permission> Collection();
        void InsertRange(List<Permission> model);
        void Commit();
        Permission Find(Guid Id);
        void Update(Permission permission);
        void Delete(Guid Id);
        List<PermissionViewModel> GetPermission(Guid RoleId);
       

    }
}
