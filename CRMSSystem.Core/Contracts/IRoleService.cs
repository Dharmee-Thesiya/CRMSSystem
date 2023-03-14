using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.Contracts
{
    public interface IRoleService
    {
        List<Role> GetRoles();
        RoleViewModel GetRole(Guid Id);
        void CreateRole(RoleViewModel model);
        void EditRole(RoleViewModel model);
        void DeleteRole(RoleViewModel model);
        
        

    }
}
