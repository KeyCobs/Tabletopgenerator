using Microsoft.EntityFrameworkCore;
using Tabletopgenerator.Models.Entity;
using Tabletopgenerator.Models.Mapper;

namespace Tabletopgenerator.Models
{
    public class MyDbContext : DbContext
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
            //Names
            builder.ApplyConfiguration(new FirstNameConfiguration());
            builder.ApplyConfiguration(new LastNameConfiguration());

            //Race
            builder.ApplyConfiguration(new RaceConfiguration());

            //Type
            builder.ApplyConfiguration(new SettingTypeConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
