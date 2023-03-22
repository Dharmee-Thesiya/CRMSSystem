using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using CRMSSystem.Core.View;
using CRMSSystem.SQL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.SQL
{
    public class UserRepository : IUserRepository
    {
        internal DataContext context;
        internal DbSet<User> dbSet;
        internal DbSet<UserRole> userRolebdSet;

        public UserRepository(DataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<User>();
            this.userRolebdSet = context.Set<UserRole>();

        }
        public IQueryable<User> Collection()
        {
            return dbSet;
        }


        public void Commit()
        {
            context.SaveChanges();
        }

        public User Find(Guid Id)
        {
            return dbSet.Find(Id)
;
        }

        public void Insert(User user)
        {
            dbSet.Add(user);

        }

        public void Delete(Guid Id)
        {
            var user = Find(Id)
;
            if (context.Entry(user).State == EntityState.Detached)
                dbSet.Attach(user);
            dbSet.Remove(user);

        }
        public void Update(User user)
        {
            dbSet.Attach(user);
            context.Entry(user).State = EntityState.Modified;

        }
        public void UpdateUserRole(UserRole userRole)
        {
            userRolebdSet.Attach(userRole);
            context.Entry(userRole).State = EntityState.Modified;
        }
        public UserViewModel GetUserById(Guid Id)
        {
            var users = (from u in context.User
                         join ur in context.UserRoles on u.Id equals ur.UserId
                         join r in context.Roles on ur.RoleId equals r.Id
                         where !u.IsDeleted && !ur.IsDeleted && u.Id == Id
                         select new UserViewModel
                         {
                             Id = u.Id,
                             Name = u.Name,
                             Email = u.Email,
                             RoleId = ur.RoleId,
                             RoleName=r.Name

                         }).FirstOrDefault();
            return users;

        }
        public List<UserViewModel> GetUsers()
        {
            var users = (from u in context.User
                         join ur in context.UserRoles on u.Id equals ur.UserId
                         join r in context.Roles on ur.RoleId equals r.Id
                         where !u.IsDeleted && !ur.IsDeleted && !r.IsDeleted
                         orderby u.Id descending
                         select new UserViewModel
                         {
                             Id = u.Id,
                             RoleId = r.Id,
                             Name = u.Name,
                             RoleName = r.Name,
                             Email = u.Email,
                             Password = u.Password

                         }).ToList();
            return users;
        }

    }
}

