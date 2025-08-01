using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tabletopgenerator.Models.Entity;

namespace Tabletopgenerator.Models.Mapper
{
    public class LastNameConfiguration : IEntityTypeConfiguration<LastName>
    {
        public void Configure(EntityTypeBuilder<LastName> builder)
        {
            builder.HasOne(l => l.SettingType)
                   .WithMany(x => x.LastNames)
                   .HasForeignKey(x => x.Id);

            builder.HasOne(l => l.Race)
                   .WithMany(x => x.LastNames)
                   .HasForeignKey(x => x.Id);

        }
    }
}
