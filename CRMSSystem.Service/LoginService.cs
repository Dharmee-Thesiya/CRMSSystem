using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using CRMSSystem.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace CRMSSystem.Service
{
    public class LoginService : ILoginService
    {
        ILoginRepository _loginRepository;
        IUserRepository _userRepository;
        public LoginService(ILoginRepository loginRepository, IUserRepository userRepository)
        {
            _loginRepository = loginRepository;
            _userRepository = userRepository;
        }

        public User Login(AccountViewModel model)
        {
            User user = _loginRepository.Login(model);
            if (user != null)
            {
                string hash = HashPasword(model.Password, user.Passwordsalt);
                if (hash.SequenceEqual(user.Password))
                {
                    return user;
                }
            }
            return null;

        }
        private string HashPasword(string Password, string salt)
        {
            string stringDataToHash = Password + "" + salt;
            HashAlgorithm hashAlg = new SHA256CryptoServiceProvider();
            byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(stringDataToHash);
            byte[] bytHash = hashAlg.ComputeHash(bytValue);
            string base64 = Convert.ToBase64String(bytHash);
            return base64;
        }
        public User ChangePassword(AccountViewModel model)
        {
            if (model.CurrentPassword != model.NewPassword)
            {
                var userpass = _loginRepository.ChangePassword(model);
                if (userpass != null)
                {
                    string hash = HashPasword(model.CurrentPassword, userpass.Passwordsalt);
                    if (hash.SequenceEqual(userpass.Password))
                    {
                        userpass.Password = HashPasword(model.NewPassword, userpass.Passwordsalt);
                        _userRepository.Update(userpass);
                        _userRepository.Commit();
                        return userpass;
                    }
                }
            }
            return null;
        }
    }
}





