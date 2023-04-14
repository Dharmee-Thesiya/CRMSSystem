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
            var permission = Find(Id);

            if (context.Entry(permission).State == EntityState.Detached)
                dbSet.Attach(permission);
            dbSet.Remove(permission);
        }

        public Permission Find(Guid Id)
        {
            return dbSet.Find(Id);
        }

        public List<PermissionViewModel> GetPermission(Guid RoleId)
        {
            var permission = context.Permissions.Where(x=>x.RoleId==RoleId).FirstOrDefault();
            if(permission==null)
            {
                var permissions = (from f in context.Form
                             where !f.IsDeleted 
                             orderby f.CreatedOn descending
                             select new PermissionViewModel
                             {

                                 FormId = f.Id,
                                 FormName = f.Name,
                                 RoleId = RoleId,
                                 View = false,
                                 Insert = false,
                                 Update = false,
                                 Delete = false

                             }).ToList();
                return permissions;
            }
            else
            {
                var result = (from f in context.Form
                                   join p in context.Permissions on f.Id equals p.FormId
                                   where !f.IsDeleted && p.RoleId == RoleId
                                   orderby f.Name ascending
                                   select new PermissionViewModel
                                   {
                                       FormId = f.Id,
                                       FormName = f.Name,
                                       RoleId = RoleId,
                                       View = p.View,
                                       Insert = p.Insert,
                                       Update = p.Update,
                                       Delete = p.Delete
                                   }).ToList();


                var forms = (from f in context.Form
                             where !f.IsDeleted
                             orderby f.Name ascending
                             select new PermissionViewModel
                             {
                                 FormId = f.Id,
                                 FormName = f.Name,
                                 RoleId = RoleId,
                                 View = false,
                                 Insert = false,
                                 Update = false,
                                 Delete = false
                             }).ToList();

                var getpermission = forms.Except(result).ToList();
                var managepermission = result.Union(getpermission).ToList();
                return managepermission;
            }
            
            
        }

        public void InsertRange(List<Permission> permission)
        {
            dbSet.AddRange(permission);
            Commit();
        }

        public void Update(Permission permission)
        {
            dbSet.Attach(permission);
            context.Entry(permission).State = EntityState.Modified;
        }
    }
}
