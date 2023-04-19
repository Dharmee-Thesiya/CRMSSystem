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
    public class PermissionService : IPermissionService
    {
        IPermissionRepository _permissionRepository;
        IFormService _formService;
        public PermissionService(IPermissionRepository permissionRepository,IFormService formService)
        {
            _permissionRepository = permissionRepository;
            _formService = formService;
        }
        public List<PermissionViewModel> GetPermissionList(Guid RoleId)
        {
            return _permissionRepository.GetPermission(RoleId).ToList();
        }

        public void UpdatePermission(List<Permission> model)
        {
           
            _permissionRepository.InsertRange(model);
            

        } 
    }
}
