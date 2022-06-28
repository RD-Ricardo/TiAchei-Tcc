using Microsoft.EntityFrameworkCore;
using TiAchei_Tcc.Models;

namespace TiAchei_Tcc.Config
{
    public class PessoaConfig : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Pessoa> builder)
        {
            builder.Property(x => x.Nome).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(X => X.FotoUrl).HasColumnType("VARCHAR(250)");
        }
    }
}