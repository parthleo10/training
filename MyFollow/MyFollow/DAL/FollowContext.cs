using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using MyFollow.Models;

namespace MyFollow.DAL
{
     public class FollowContext : DbContext
    {
            public FollowContext()
            : base("DefaultConnection")
            {
            }
         
            public DbSet<Produ> Product { get; set; }

           
        }
}