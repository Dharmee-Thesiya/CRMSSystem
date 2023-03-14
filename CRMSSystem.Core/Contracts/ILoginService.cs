using CRMSSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.Contracts
{
    public interface ILoginService
    {
        User Login(AccountViewModel model);
    }
}
