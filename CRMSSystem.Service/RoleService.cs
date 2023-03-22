using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using CRMSSystem.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.Service
{
    public class RoleService : IRoleService
    {
        IRoleRepository roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }
        public List<Role> GetRoles()
        {
            return roleRepository.Collection().Where(x => !x.IsDeleted).ToList();
        }

        public void CreateRole(RoleViewModel model)
        {
            Role role = new Role();
            role.Code = model.Code;
            role.Name = model.Name;
            //role.Id = model.Id;

            roleRepository.Insert(role);
            roleRepository.Commit();
        }
        public void EditRole(RoleViewModel model)
        {
            Role role = roleRepository.Collection().Where(x => x.Id == model.Id).FirstOrDefault();
            role.Name = model.Name;
            role.Code = model.Code;
            //role.Id = model.Id;
            role.UpdatedOn = DateTime.Now;

            roleRepository.Update(role);
            roleRepository.Commit();
        }

        public RoleViewModel GetRole(Guid Id)
        {
            var role = roleRepository.Find(Id);

            RoleViewModel roleViewModel = new RoleViewModel();
            roleViewModel.Id = role.Id;
            roleViewModel.Name = role.Name;
            roleViewModel.Code = role.Code;
            return roleViewModel;
        }

        public void DeleteRole(RoleViewModel model)
        {
            var role = roleRepository.Collection().Where(x => x.Id ==model.Id).FirstOrDefault();
            role.IsDeleted = true;
            roleRepository.Update(role);
            roleRepository.Commit();
        }
    }
}


    


