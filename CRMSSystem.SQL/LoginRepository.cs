using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.SQL
{
    public class LoginRepository : ILoginRepository
    {
        internal DataContext context;

        public LoginRepository(DataContext context)
        {
            this.context = context;
        }
        public User Login(AccountViewModel model)
        {
            var user = context.User.Where(User => User.Email == model.Email && !User.IsDeleted).FirstOrDefault();
            return user;
        }
    }
}


