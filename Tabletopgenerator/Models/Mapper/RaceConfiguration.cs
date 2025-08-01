using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tabletopgenerator.Models.Entity;

namespace Tabletopgenerator.Models.Mapper
{
    public class RaceConfiguration : IEntityTypeConfiguration<Race>
    {
        public void Configure(EntityTypeBuilder<Race> builder)
        {
            builder.HasMany(r => r.FirstNames)
                   .WithOne(x => x.Race)
                   .HasForeignKey(x => x.RaceId);
            builder.HasMany(r => r.LastNames)
                   .WithOne(x => x.Race)
                   .HasForeignKey(x => x.RaceId);

        }
    }
}
