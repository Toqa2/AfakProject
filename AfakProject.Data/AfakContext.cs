using AfakProject.Data.DatabaseModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AfakProject.Data
{
    public class AfakContext : IdentityDbContext<ApplicationUser>
    {
        public AfakContext()
        {

        }
        public AfakContext(DbContextOptions<AfakContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

                var connectionString = configuration.GetConnectionString("AfakConnectionString");
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();
        }

        #region DB Sets

        public virtual DbSet<ApplicationUser> User { get; set; }
        public virtual DbSet<Certification> Certification { get; set; }
        public virtual DbSet<UserCertification> UserCertification { get; set; }

        #endregion

    }
}