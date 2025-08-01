using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tabletopgenerator.Models.Entity;

namespace Tabletopgenerator.Models.Mapper
{
    public class SettingTypeConfiguration : IEntityTypeConfiguration<SettingType>
    {
        public void Configure(EntityTypeBuilder<SettingType> builder)
        {
            builder.HasMany(r => r.FirstNames)
                   .WithOne(x => x.SettingType)
                   .HasForeignKey(x => x.RaceId);
            builder.HasMany(r => r.LastNames)
                   .WithOne(x => x.SettingType)
                   .HasForeignKey(x => x.RaceId);

        }
    }
}
