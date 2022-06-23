using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TiAchei_Tcc.Models;

namespace TiAchei_Tcc.Config
{
    public class PetConfig : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasColumnType("VARCHAR(30)").IsRequired();
            builder.Property(x => x.Raca).HasColumnType("VARCHAR(30)").IsRequired();
            builder.Property(x => x.Foto).HasColumnType("VARCHAR(250)");
            builder.Property(x => x.CategoriaPetId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
        }
    }
}