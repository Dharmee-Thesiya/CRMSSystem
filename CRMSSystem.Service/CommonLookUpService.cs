using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using CRMSSystem.SQL.Migrations;
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

        public CommonLookUp CreateCommonLookUp(CommonLookUp model)
        {
           CommonLookUp commonLookUp = _commonLookUpRepository.Collection().Where(cl => cl.ConfigName == model.ConfigName && cl.ConfigKey==model.ConfigKey && !cl.IsDeleted).FirstOrDefault();
           if(commonLookUp == null)
            {
                CommonLookUp commonlookup = new CommonLookUp();
                commonlookup.ConfigName = model.ConfigName;
                commonlookup.ConfigKey = model.ConfigKey;
                commonlookup.ConfigValue = model.ConfigValue;
                commonlookup.Description = model.Description;
                commonlookup.DisplayOrder = model.DisplayOrder;

                _commonLookUpRepository.Insert(commonlookup);
                _commonLookUpRepository.Commit();
                return commonlookup;
            }
           else
            {
                return null;  
            }
        }

        public void DeleteCommonLookUp(Guid id)
        {
            CommonLookUp commonLookUp = _commonLookUpRepository.Collection().Where(cl => cl.Id==id).FirstOrDefault();
            commonLookUp.IsDeleted = true;
            _commonLookUpRepository.Update(commonLookUp);
            _commonLookUpRepository.Commit();
           
        }

        public CommonLookUp EditCommonLookUp(CommonLookUp model)
        {
            CommonLookUp commonLookUp = _commonLookUpRepository.Collection().Where(cl => cl.ConfigName == model.ConfigName && cl.ConfigKey == model.ConfigKey && !cl.IsDeleted && cl.Id != model.Id).FirstOrDefault();
            if(commonLookUp==null)
            {
                CommonLookUp commonlookup = _commonLookUpRepository.Collection().Where(cl => cl.Id == model.Id).FirstOrDefault();
                commonlookup.ConfigKey = model.ConfigKey;
                commonlookup.ConfigName = model.ConfigName;
                commonlookup.ConfigValue = model.ConfigValue;
                commonlookup.Description = model.Description;
                commonlookup.DisplayOrder = model.DisplayOrder;

                _commonLookUpRepository.Update(commonlookup);
                _commonLookUpRepository.Commit();
                return (commonlookup);
            }
            else
            {
                return null;
            }
        }

        public List<CommonLookUp> GetCommonLookUp()
        {
            return _commonLookUpRepository.Collection().Where(cl => !cl.IsDeleted).OrderByDescending(x => x.CreatedOn).ToList();

        }

        public CommonLookUp GetCommonLookUp(Guid Id)
        {
            CommonLookUp commonLookUp = _commonLookUpRepository.Find(Id);
            //CommonLookUp commonLookUpViewModel = new CommonLookUp();
            return commonLookUp;
            
        }
 
    }
}
