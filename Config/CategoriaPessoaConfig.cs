using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TiAchei_Tcc.Models;

namespace TiAchei_Tcc.Config
{
     public class CategoriaPessoaConfig : IEntityTypeConfiguration<CategoriaPessoa>
    {
        public void Configure(EntityTypeBuilder<CategoriaPessoa> builder)
        {
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
        }
    }
}