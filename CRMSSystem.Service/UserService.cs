using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        IMRepository<UserRole> _userRoleRepository;
        public UserService(IUserRepository userRepository, IMRepository<UserRole> userRoleRepository)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
        }
        public void CreateUser(UserViewModel model)
        {
            User user = new User();
            user.Name = model.Name;
            user.Email = model.Email;
            user.Password = model.Password;

            _userRepository.Insert(user);
            _userRepository.Commit();
            UserRole userRole = new UserRole();
            userRole.RoleId = model.RoleId;
            userRole.UserId = user.Id;
            _userRoleRepository.Insert(userRole);
            _userRoleRepository.Commit();

        }

        public void DeleteUser(Guid Id)
        {
            UserViewModel model = new UserViewModel();
            User user = _userRepository.Collection().Where(x => x.Id == Id).FirstOrDefault();
            user.IsDeleted = true;
            _userRepository.Update(user);
            _userRepository.Commit();

            UserRole userRole = _userRoleRepository.Collection().Where(x => x.UserId == Id).FirstOrDefault();
            userRole.IsDeleted = true;
            _userRoleRepository.Update(userRole);
            _userRoleRepository.Commit();
        }

        public void EditUser(UserViewModel model)
        {
            User user = _userRepository.Collection().Where(x => x.Id == model.Id).FirstOrDefault();
            user.Name = model.Name;
            user.Email = model.Email;
            user.UpdatedOn = DateTime.Now;
            _userRepository.Update(user);
            _userRepository.Commit();

            UserRole userRole = _userRoleRepository.Collection().Where(x => x.UserId == model.Id).FirstOrDefault();
            userRole.RoleId = model.RoleId;
            userRole.UpdatedOn = DateTime.Now;
            _userRoleRepository.Update(userRole);
            _userRoleRepository.Commit();


        }
        public UserViewModel GetUser(Guid Id)
        {
            return _userRepository.GetUserById(Id);

        }

        public List<UserViewModel> GetUsers()
        {
            //return userRepository.Collection().Where(x => !x.IsDeleted).ToList();
            return _userRepository.GetUsers();

        }
    }
}