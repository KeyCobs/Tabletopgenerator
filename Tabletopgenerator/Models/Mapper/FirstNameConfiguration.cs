using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tabletopgenerator.Models.Entity;

namespace Tabletopgenerator.Models.Mapper
{
    public class FirstNameConfiguration : IEntityTypeConfiguration<FirstName>
    {
        public void Configure(EntityTypeBuilder<FirstName> builder)
        {
            builder.HasOne(f => f.SettingType)
                   .WithMany(x => x.FirstNames)
                   .HasForeignKey(x => x.Id);

            builder.HasOne(f => f.Race)
                   .WithMany(x => x.FirstNames)
                   .HasForeignKey(x => x.Id);

        }
    }
}
