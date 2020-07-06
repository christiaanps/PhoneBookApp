using Microsoft.EntityFrameworkCore;
using PhoneBookApp.Infrastructures.DataLayer.Entries;
using PhoneBookApp.Infrastructures.DataLayer.PhoneBooks;
using PhoneBookApp.Domain.Core.Entries;
using PhoneBookApp.Domain.Core.PhoneBooks;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.Extensions.Options;
using IdentityServer4.EntityFramework.Options;
using PhoneBookApp.Domain.Core.ApplicationUsers;

namespace PhoneBookApp.Infrastructures.DataLayer.Common
{
    public class PhoneBookAppContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<PhoneBook> PhoneBooks { get; set; }
        public DbSet<Entry> Entries { get; set; }

        public PhoneBookAppContext(DbContextOptions<PhoneBookAppContext> options, IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PhoneBookConfig());
            modelBuilder.ApplyConfiguration(new EntryConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
