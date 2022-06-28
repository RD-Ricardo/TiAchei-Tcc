using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TiAchei_Tcc.Models;

namespace TiAchei_Tcc.Config
{
    public class EnfermidadePessoaConfig : IEntityTypeConfiguration<EnfermidadePessoa>
    {
        public void Configure(EntityTypeBuilder<EnfermidadePessoa> builder)
        {
            builder.Property(x => x.Id).HasColumnType("VARCHAR(100)").IsRequired();
        }
    }
}