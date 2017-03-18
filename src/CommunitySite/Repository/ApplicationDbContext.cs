using Microsoft.EntityFrameworkCore;
using CommunitySite.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CommunitySite.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) //ApplicationdbContesxt should be renamed to something useful
            : base(options) { }

        public DbSet<ParkMember> ParkMembers { get; set; }
        public DbSet<ForumMessage> ForumMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modBuilder)
        {
            base.OnModelCreating(modBuilder);
            modBuilder.Ignore<IdentityUserLogin<string>>();
            modBuilder.Ignore<IdentityUserRole<string>>();
            modBuilder.Ignore<IdentityUserClaim<string>>();
            modBuilder.Ignore<IdentityUserToken<string>>();
            modBuilder.Ignore<IdentityUser<string>>();
        }

    }
}
