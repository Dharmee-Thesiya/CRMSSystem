﻿using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.Contracts
{
    public interface IRoleRepository
    {
        IQueryable<Role> Collection();
        void Commit();
        void Delete(Guid Id);
        Role Find(Guid Id);
        void Insert(Role role);
        void Update(Role role);
        
    }
}
