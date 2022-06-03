using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TiAchei_Tcc.Models;

namespace TiAchei_Tcc.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.UserName).IsRequired();
            builder.Property(x => x.UrlFacebook).HasColumnType("VARCHAR(150)");
            builder.Property(x => x.UrlInstagram).HasColumnType("VARCHAR(150)");
        }
    }
}