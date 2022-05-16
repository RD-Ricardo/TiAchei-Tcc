using Microsoft.EntityFrameworkCore;
using TiAchei_Tcc.Models;

namespace TiAchei_Tcc.Config
{
    public class RedeSocialConfig : IEntityTypeConfiguration<RedeSocial>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<RedeSocial> builder)
        {
            builder.Property(x => x.Nome).HasColumnType("VARCHAR(30)").IsRequired();
            builder.Property(x => x.UrlRede).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(x=> x.UserId).IsRequired();
        }
    }
}