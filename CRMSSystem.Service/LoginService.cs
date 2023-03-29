using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using CRMSSystem.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Service
{
    public class LoginService : ILoginService
    {
        ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public User Login(AccountViewModel model)
        {
            User user = _loginRepository.Login(model);
            string hash = HashPasword(model.Password, user.Passwordsalt);
            if (hash.SequenceEqual(user.Password))
            {
                return user;
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
    }
}
      
                

  

