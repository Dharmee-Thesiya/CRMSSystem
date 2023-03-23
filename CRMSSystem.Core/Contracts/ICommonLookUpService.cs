using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.Contracts
{
    public interface ICommonLookUpService
    {
        List<CommonLookUp> GetCommonLookUp();
        CommonLookUp GetCommonLookUp(Guid Id);
        void EditCommonLookUp(CommonLookUp model);
        void CreateCommonLookUp(CommonLookUp model);
        void DeleteCommonLookUp(Guid id);
       

    }
}
