using Microsoft.AspNetCore.Identity;

namespace TiAchei_Tcc.Models
{
    public class User : IdentityUser
    {
        public string  UrlFacebook { get; set; }
        public string  UrlInstagram { get; set; }
        public string FotoUrl { get; set; }
        public ICollection<Pet> Pets { get; set; }
        public ICollection<Pessoa> Pessoas { get; set; }
        public ICollection<EnfermidadePessoa> EnfermidadePessoa { get; set; }
        public ICollection<CategoriaPet> CategoriPet { get; set; }
    }
}