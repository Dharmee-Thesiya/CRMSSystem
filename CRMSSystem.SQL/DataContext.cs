using CRMSSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSSystem.SQL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }
            public DbSet<Role> Roles { get; set; }
            public DbSet<UserRole> UserRoles { get; set; }
            public DbSet<User> User { get; set; }
            public DbSet<CommonLookUp> CommonLookUps { get; set; }
            public DbSet<Forms> Form { get; set; }
            public DbSet<Permission> Permissions { get; set; }
            public DbSet<Ticket> Ticket { get; set; }
            public DbSet<TicketStatusHistory> TicketStatusHistory { get; set; }
            public DbSet<TicketAttachment> TicketAttachment { get; set; }
            public DbSet<TicketComment>TicketComment { get; set; }




    }

}
