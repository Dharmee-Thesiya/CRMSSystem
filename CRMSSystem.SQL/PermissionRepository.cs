using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.SQL
{
    public class PermissionRepository : IPermissionRepository
    {
        internal DataContext context;
        internal DbSet<Permission> dbSet;
        public PermissionRepository(DataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<Permission>();
        }

        public IQueryable<Permission> Collection()
        {
            return dbSet;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(Guid Id)
        {
            
        }

        public Permission Find(Guid Id)
        {
            return dbSet.Find(Id);
        }

        public List<PermissionViewModel> GetPermission(Guid RoleId)
        {
            int count = 0;
            var permissions = (from f in context.Form.Where(x => !x.IsDeleted).AsEnumerable()
                               join p in context.Permissions.Where(x => x.RoleId == RoleId) on f.Id equals p.FormId into fdata
                               from fp in fdata.DefaultIfEmpty()
                               select new PermissionViewModel
                               {
                                   RoleId = RoleId,
                                   FormId = f.Id,
                                   FormName = f.Name,
                                   NavigateURL=f.NavigateURL,
                                   View = fp != null ? fp.View : false,
                                   Update = fp != null ? fp.Update : false,
                                   Delete = fp != null ? fp.Delete : false,
                                   Insert = fp != null ? fp.Insert : false  
                               }).ToList();

            foreach (var mod in permissions)
            {
                if (mod.View && mod.Insert && mod.Update && mod.Delete)
                {
                    count += 1;
                }
            }
            if (count == permissions.Count())
            {
                Constants.All = true;
            }
            else
            {
                Constants.All = false;
            }
            return permissions;
 
        }

        public void InsertRange(List<Permission> model)
        {
            var permissions = Collection().ToList().Where(x => x.RoleId == model.FirstOrDefault().RoleId);
            dbSet.RemoveRange(permissions);
            Commit();
            dbSet.AddRange(model);
            Commit();
        }

        public void Update(Permission permission)
        {
            dbSet.Attach(permission);
            context.Entry(permission).State = EntityState.Modified;
        }
    }
}
