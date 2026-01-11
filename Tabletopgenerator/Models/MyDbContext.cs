using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tabletopgenerator.Models.Entity;
using Tabletopgenerator.Models.Entity.Login;
using Tabletopgenerator.Models.Mapper;

namespace Tabletopgenerator.Models
{
    public class MyDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) {}
       

        // Names
        public DbSet<FirstName> tblFirstName { get; set; }
        public DbSet<LastName> tblLastName { get; set; }

        //Race
        public DbSet<Race> tblRace { get; set; }

        //Type
        public DbSet<SettingType> tblType { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Names
            builder.ApplyConfiguration(new FirstNameConfiguration());
            builder.ApplyConfiguration(new LastNameConfiguration());

            //Race
            builder.ApplyConfiguration(new RaceConfiguration());

            //Type
            builder.ApplyConfiguration(new SettingTypeConfiguration());


            // Rename tables
            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<ApplicationRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens");
            // Seed initial roles using HasData
            var adminRoleId = Guid.Parse("c8d89a25-4b96-4f20-9d79-7f8a54c5213d");
            var userRoleId = Guid.Parse("b92f0a3e-573b-4b12-8db1-2ccf6d58a34a");
            var testerRoleId = Guid.Parse("d7f4a42e-1c1b-4c9f-8a50-55f6b234e8e2");
            builder.Entity<ApplicationRole>().HasData(
                new ApplicationRole { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN", Description = "Administrator role with full permissions.", IsActive = true, CreatedOn = new DateTime(2026, 1, 8), UpdatedOn = new DateTime(2026, 1, 8) },
                new ApplicationRole { Id = userRoleId, Name = "UserFree", NormalizedName = "USERFREE", Description = "Standard user role.", IsActive = true, CreatedOn = new DateTime(2026, 1, 8), UpdatedOn = new DateTime(2026, 1, 8) },
                new ApplicationRole { Id = testerRoleId, Name = "Tester", NormalizedName = "TESTER", Description = "Tester user role for testing purpose. Everything will be monitored and has limited access", IsActive = true, CreatedOn = new DateTime(2026, 1, 8), UpdatedOn = new DateTime(2026, 1, 8) }
            );
        }

    }
}
