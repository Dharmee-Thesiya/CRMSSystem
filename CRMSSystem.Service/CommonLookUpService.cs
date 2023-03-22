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

    public class CommonLookUpService : ICommonLookUpService
    {
        IMRepository<CommonLookUp> _commonLookUpRepository;
        public CommonLookUpService(IMRepository<CommonLookUp> commonLookUpRepository)
        {
            _commonLookUpRepository = commonLookUpRepository;
        }

        public void CreateCommonLookUp(CommonLookUp model)
        {
            CommonLookUp commonLookUp = new CommonLookUp();
            //commonLookUp.ConfigName = model.ConfigName;
            //commonLookUp.ConfigKey = model.ConfigKey;
            //commonLookUp.ConfigValue = model.ConfigValue;
            //commonLookUp.Description = model.Description;
            //commonLookUp.DisplayOrder = model.DisplayOrder;
            _commonLookUpRepository.Insert(commonLookUp);
            _commonLookUpRepository.Commit();
            
        }

        public void DeleteCommonLookUp(Guid id)
        {
            CommonLookUp commonLookUp = _commonLookUpRepository.Collection().Where(cl => cl.Id==id).FirstOrDefault();
            commonLookUp.IsDeleted = true;
            _commonLookUpRepository.Update(commonLookUp);
            _commonLookUpRepository.Commit();
           
        }

        public void EditCommonLookUp(CommonLookUpViewModel model)
        {
            CommonLookUp commonLookUp = _commonLookUpRepository.Collection().Where(cl => cl.Id == model.Id).FirstOrDefault();
            commonLookUp.ConfigKey = model.ConfigKey;
            commonLookUp.ConfigName = model.ConfigName;
            commonLookUp.ConfigValue = model.ConfigValue;
            commonLookUp.Description = model.Description;
            commonLookUp.DisplayOrder = model.DisplayOrder;

            _commonLookUpRepository.Update(commonLookUp);
            _commonLookUpRepository.Commit();
          
        }

        public List<CommonLookUp> GetCommonLookUp()
        {
            return _commonLookUpRepository.Collection().Where(cl => !cl.IsDeleted).ToList();

        }

        public CommonLookUpViewModel GetCommonLookUp(Guid Id)
        {
            CommonLookUp commonLookUp = _commonLookUpRepository.Find(Id);
            CommonLookUpViewModel commonLookUpViewModel = new CommonLookUpViewModel();
            commonLookUpViewModel.ConfigName = commonLookUp.ConfigName;
            commonLookUpViewModel.ConfigKey = commonLookUp.ConfigKey;
            commonLookUpViewModel.ConfigValue = commonLookUp.ConfigValue;
            commonLookUpViewModel.DisplayOrder = commonLookUp.DisplayOrder;
            commonLookUpViewModel.Description = commonLookUp.Description;
            return commonLookUpViewModel;
            
        }
 
    }
}
