using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        public string CreateUser(UserViewModel model)
        {
            if(_userRepository.Collection().Where(u=>u.UserName==model.UserName && !u.IsDeleted).Any())
            {
                return "UserName Already Exists";
            }
            if(_userRepository.Collection().Where(u => u.Email == model.Email && !u.IsDeleted).Any())
            {
                return "Email Already Exists";
            }
            User user = new User();
            string salt = "";
            string password = HashPasword(model.Password, out salt);

            user.Name = model.Name;
            user.Email = model.Email;
            user.Password = password;
            user.MobileNumber = model.MobileNumber;
            user.Passwordsalt = salt;
            user.UserName = model.UserName;
            
            user.Gender = model.Gender;

            _userRepository.Insert(user);
            _userRepository.Commit();

            UserRole userRole = new UserRole();
            userRole.RoleId = model.RoleId;
            userRole.UserId = user.Id;
            _userRoleRepository.Insert(userRole);
            _userRoleRepository.Commit();

            return null;
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

        public string EditUser(UserViewModel model)
        {
            if(_userRepository.Collection().Where(u => u.Id != model.Id && u.UserName == model.UserName && !u.IsDeleted).Any())
            {
                return "UserName Already Exists";
            }
            if (_userRepository.Collection().Where(u => u.Id != model.Id &&u.Email == model.Email && !u.IsDeleted).Any())
            {
                return "Email Already Exists";
            }
            User user = _userRepository.Collection().Where(x => x.Id == model.Id).FirstOrDefault();
            user.Name = model.Name;
            user.Email = model.Email;
            user.UpdatedOn = DateTime.Now;
            user.UserName = model.UserName;
            user.MobileNumber = model.MobileNumber;
            user.Gender = model.Gender;
         

            _userRepository.Update(user);
            _userRepository.Commit();

            UserRole userRole = _userRoleRepository.Collection().Where(x => x.UserId == model.Id).FirstOrDefault();
            userRole.RoleId = model.RoleId;
            userRole.UpdatedOn = DateTime.Now;
            _userRoleRepository.Update(userRole);
            _userRoleRepository.Commit();

            return null;

        }
        public UserViewModel GetUser(Guid Id)
        {
            return _userRepository.GetUserById(Id);

        }
        public List<UserViewModel> GetUsers()
        {
            //return _userRepository.Collection().Where(x => !x.IsDeleted).ToList();
            return _userRepository.GetUsers();
        }
        private static string CreateSalt(int size)
        {
            // Generate a cryptographic random number using the cryptographic 
            // service provider
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);
            // Return a Base64 string representation of the random number
            return Convert.ToBase64String(buff);
        }


        private string HashPasword(string Password, out string salt)
        {
            salt = CreateSalt(64);
            string stringDataToHash = Password + "" + salt;
            HashAlgorithm hashAlg = new SHA256CryptoServiceProvider();
            byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(stringDataToHash);
            byte[] bytHash = hashAlg.ComputeHash(bytValue);
            string base64 = Convert.ToBase64String(bytHash);
            return base64;
        }
    }
}