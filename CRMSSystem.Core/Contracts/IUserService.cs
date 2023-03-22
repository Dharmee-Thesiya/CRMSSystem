using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.Contracts
{
    public interface IUserService
    {
        List<UserViewModel> GetUsers();
        UserViewModel GetUser(Guid Id);
        void CreateUser(UserViewModel model);
        void EditUser(UserViewModel model);
        void DeleteUser(Guid Id);
       
    }
}

