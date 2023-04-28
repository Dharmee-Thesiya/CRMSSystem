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
    public class RoleRepository : IRoleRepository
    {
        internal DataContext context;
        internal DbSet<Role> DbSet;
        

        public RoleRepository(DataContext context)
        {
            this.context = context;
            this.DbSet = context.Set<Role>();
        }
        public IQueryable<Role> GetRoles()
        {
            return DbSet;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(Guid Id)
        {
            var role = Find(Id);
            if (context.Entry(role).State == EntityState.Detached)
            {
                DbSet.Attach(role);
            }
            DbSet.Remove(role);
        }
        public Role Find(Guid Id)
        {
            return DbSet.Find(Id);
        }

        public void Insert(Role role)
        {
            DbSet.Add(role);
        }

        public void Update(Role role)
        {
            DbSet.Attach(role);
            context.Entry(role).State = EntityState.Modified;
        }

        public IQueryable<Role> Collection()
        {
            return DbSet;
        }
    }
}
