
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TiAchei_Tcc.Config;
using TiAchei_Tcc.Models;

namespace TiAchei_Tcc.Db
{
    public class AppDbContextMysql : IdentityDbContext<User>
    {
        public AppDbContextMysql(DbContextOptions<AppDbContextMysql> options) : base(options) {}
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new PetConfig());
            builder.ApplyConfiguration(new UserConfig());
            builder.ApplyConfiguration(new PessoaConfig());
            builder.ApplyConfiguration(new CategoriaPessoaConfig());
            builder.ApplyConfiguration(new CategoriaPetConfig());
            builder.ApplyConfiguration(new EnfermidadePessoaConfig());
        }
        public DbSet<Pet> Pets {get;set;}
        public DbSet<Pessoa> Pessoas {get;set;}
        public DbSet<CategoriaPet> CategoriaPets { get; set; }
        public DbSet<EnfermidadePessoa> EnfermidadePessoas { get; set; }
    }
}