using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.Contracts
{
    public interface IUserRepository
    {
            IQueryable<User> Collection();
            void Insert(User user);
            void Commit();
            User Find(Guid Id);
            void Update(User user);
            void UpdateUserRole(UserRole userRole);
            void Delete(Guid Id);
            List<UserViewModel> GetUsers();
            UserViewModel GetUserById(Guid Id);
           
    }
    }

