
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TiAchei_Tcc.Models;

namespace TiAchei_Tcc.Db
{
    public class AppDbContextMysql : IdentityDbContext<User>
    {
        public AppDbContextMysql(DbContextOptions<AppDbContextMysql> options) : base(options)
        {
            
        }

        public DbSet<Pet> Pets {get;set;}
        public DbSet<RedeSocial> RedeSocials {get;set;}
    }
}