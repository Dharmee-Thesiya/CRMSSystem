using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Service
{
    public class FormsService : IFormService
    {
        IFormRepository _formRepository;
       
        public FormsService(IFormRepository formRepository)
        {
            _formRepository = formRepository;
        }
        public string CreateForms(FormsViewModel model)
        {
            if (_formRepository.Collection().Where(r => r.FormAccessCode == model.FormAccessCode && !r.IsDeleted).Any())
            {
                return "FormAccessCode Already Exist";
            }
                Forms forms = new Forms();
                forms.Name = model.Name;
                forms.NavigateURL = model.NavigateURL;
                if (model.ParentFormID != null)
                {
                    forms.ParentFormID = model.ParentFormID;
                }
                forms.FormAccessCode = model.FormAccessCode.ToUpper();
                forms.DisplayIndex = model.DisplayIndex;
                _formRepository.Insert(forms);
                _formRepository.Commit();
            return null;
        }

        public void DeleteForms(Guid Id)
        {
            FormsViewModel model = new FormsViewModel();
            Forms forms = _formRepository.Collection().Where(x => x.Id == Id).FirstOrDefault();
            forms.IsDeleted = true;
            _formRepository.Update(forms);
            _formRepository.Commit();
        }

        public string EditForms(FormsViewModel model)
        {
            if (_formRepository.Collection().Where(r => r.Id != model.Id && r.FormAccessCode == model.FormAccessCode && !r.IsDeleted).Any())
            {
                return "FormAccessCode Already Exist";
            }
            Forms forms = _formRepository.Collection().Where(f => f.Id == model.Id).FirstOrDefault();
            forms.Name = model.Name;
            forms.NavigateURL = model.NavigateURL;
            forms.FormAccessCode = model.FormAccessCode;
            forms.DisplayIndex = model.DisplayIndex;
            forms.ParentFormID = model.ParentFormID;
            
            _formRepository.Update(forms);
            _formRepository.Commit();

            return null;
        }

        public List<FormsViewModel> GetForm()
        {

            return _formRepository.GetForm().OrderByDescending(x => x.CreatedOn).ToList();
        }

        public FormsViewModel GetForms(Guid Id)
        {
            return _formRepository.GetFormsById(Id);
        }
    }
}
