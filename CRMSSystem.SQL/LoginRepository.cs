using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace CRMSSystem.SQL
{
    public class LoginRepository : ILoginRepository
    {
        internal DataContext context;
        internal DbSet<User> DbSet;

        public LoginRepository(DataContext context)
        {
            this.context = context;
            this.DbSet = context.Set<User>();
        }
        public User Login(AccountViewModel model)
        {
            var user = context.User.Where(User => User.Email == model.Email && !User.IsDeleted).FirstOrDefault();
            return user;
        }
        public User ChangePassword(AccountViewModel model)
        {
            var currentpass = context.User.Where(x => x.Password != null).FirstOrDefault();
            return currentpass;
        }
    }
}


