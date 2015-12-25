using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using MyFollow.Entities;

namespace MyFollow.DAL
{
     public class FollowContext : DbContext
    {
            public FollowContext()
            : base("DefaultConnection")
            {
            }

           
          
           
            public DbSet<Product> Products { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }
        }
}