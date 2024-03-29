﻿using CRMSSystem.Core.Models;
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
        string CreateRole(RoleViewModel model);
        string EditRole(RoleViewModel model);
        void DeleteRole(RoleViewModel model);

    }
}
