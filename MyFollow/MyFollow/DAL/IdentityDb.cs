using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using MyFollow.Models;

namespace MyFollow.DAL
{
    public class IdentityDb : IdentityDbContext<ApplicationUser>
    {
        public IdentityDb()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public System.Data.Entity.DbSet<Owner> Owner { get; set; }

        public System.Data.Entity.DbSet<User> User { get; set; }

        public static IdentityDb Create()
        {
            return new IdentityDb();
        }
    }
}