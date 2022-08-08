using Microsoft.EntityFrameworkCore;
using PlanTechShenApp.Models;
using PlanTechShenWebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanTechShenApp.Data
{
    public class UserContext:DbContext
    {
        internal IEnumerable<object> c;

        public UserContext(DbContextOptions options)
            : base(options)
        {
        }  

        public DbSet<Authentication> Authentication { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<UserAccount> UserAccount { get; set; }
        
    }
}
