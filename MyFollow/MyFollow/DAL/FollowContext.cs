using MyFollow.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MyFollow.DAL
{
    public class FollowContext : DbContext
    {
    
    public FollowContext() : base("FollowContext")
        {
        }

    public DbSet<EndUser> EndUsers { get; set; }
    public DbSet<AppOwner> AppOwners { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}