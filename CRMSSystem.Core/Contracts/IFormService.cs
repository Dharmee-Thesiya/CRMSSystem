using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Core.Contracts
{
    //interface for FormService//
    public interface IFormService
    {
        List<FormsViewModel> GetForm();
        FormsViewModel GetForms(Guid Id);
        string CreateForms(FormsViewModel model);
        string EditForms(FormsViewModel model);
        void DeleteForms(Guid Id);
    }
}
