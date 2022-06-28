using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TiAchei_Tcc.Models;

namespace TiAchei_Tcc.Config
{
    public class CategoriaPetConfig : IEntityTypeConfiguration<CategoriaPet>
    {
        public void Configure(EntityTypeBuilder<CategoriaPet> builder)
        {
            builder.Property(x => x.Nome).HasColumnType("VARCHAR(30)").IsRequired();
            builder.Property(x => x.UserId).IsRequired();
        }
    }
}