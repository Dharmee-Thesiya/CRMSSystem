using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
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
        internal DbSet<User> DbSet;

        public UserRepository(DataContext context)
        {
            this.context = context;
            this.DbSet = context.Set<User>();
        }



        public IQueryable<User> GetUsers()
        {
            return DbSet;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(Guid Id)
        {
            var user = Find(Id);
            if (context.Entry(user).State == EntityState.Detached)
            {
                DbSet.Attach(user);
            }
            DbSet.Remove(user);
        }
        public User Find(Guid Id)
        {
            return DbSet.Find(Id);
        }

        public void Insert(User user)
        {
            DbSet.Add(user);
        }

        public void Update(User user)
        {
            DbSet.Attach(user);
            context.Entry(user).State = EntityState.Modified;

        }

        public IQueryable<User> Collection()
        {
            return DbSet;
        }
    }
}

