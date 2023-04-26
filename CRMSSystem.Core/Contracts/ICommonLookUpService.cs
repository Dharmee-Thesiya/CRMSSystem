using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.Contracts
{
    //interface for commonlookupService//
    public interface ICommonLookUpService
    {
        List<CommonLookUp> GetCommonLookUp();
        CommonLookUp GetCommonLookUp(Guid Id);
        CommonLookUp EditCommonLookUp(CommonLookUp model);
        CommonLookUp CreateCommonLookUp(CommonLookUp model);
        void DeleteCommonLookUp(Guid id);
       

    }
}
