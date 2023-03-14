using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using CRMSSystem.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return _loginRepository.Login(model);
        }
    }
}

