using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MyFollow.Models;

namespace MyFollow.DAL
{
    public class FollowContext : DbContext
    {
            public FollowContext()
            : base("FollowContext")
            {
            }

            public DbSet<AppOwner> AppOwners { get; set; }
            public DbSet<EndUser> EndUsers { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }
        }
    
    }
