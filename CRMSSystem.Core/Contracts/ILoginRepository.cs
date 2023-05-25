using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.Contracts
{
    //interface for LoginRepository//
    public interface ILoginRepository
    {
        User Login(AccountViewModel model);
    }
}
