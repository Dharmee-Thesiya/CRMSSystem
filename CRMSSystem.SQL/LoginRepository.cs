using CRMSSystem.Core.Models;
using IdentityServer3.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.SQL
{
    public class LoginRepository
    {
        public DataContext context;
        public LoginRepository()
        {
            context = new DataContext();
        }
        public IQueryable<User> SQLRepository(LoginViewModel model)
        {
            var user = context.User.Where(User => User.UserName == "Admin");
            return user;
        }
    }
}


