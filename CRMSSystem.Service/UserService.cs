using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Service
{
    public class UserService : IUserService
    {
        IUserRepository UserContext;
        public UserService(IUserRepository UserContext)
        {
            this.UserContext = UserContext;
        }
        public void CreateUser(UserViewModel model)
        {
            User user = new User();
            user.Name = model.Name;
            user.Email = model.Email;
            user.Password = model.Password;

            UserContext.Insert(user);
            UserContext.Commit();
        }

        public void DeleteUser(UserViewModel model)
        {
            var user = UserContext.Collection().Where(x => x.Id == model.Id).FirstOrDefault();
            user.IsDeleted = true;
            UserContext.Update(user);
            UserContext.Commit();
        }

        public void EditUser(UserViewModel model)
        {
            var user = UserContext.Collection().Where(x => x.Id == model.Id).FirstOrDefault();
            user.Name = model.Name;
            user.Email = model.Email;
            user.Password = model.Password;
            user.UpdatedOn = DateTime.Now;

            UserContext.Update(user);
            UserContext.Commit();
        }

        public UserViewModel GetUser(Guid Id)
        {
            var user = UserContext.Find(Id);

            UserViewModel userViewModel = new UserViewModel();
            userViewModel.Id = user.Id;
            userViewModel.Name = user.Name;
            userViewModel.Email = user.Email;
            userViewModel.Password = user.Password;
            return userViewModel;
        }

        public List<User> GetUsers()
        {
            return UserContext.Collection().Where(x => !x.IsDeleted).ToList();
        }
    }
}
