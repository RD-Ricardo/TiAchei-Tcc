using TiAchei_Tcc.Models;

namespace TiAchei_Tcc.ViewModel
{
    public class PagePessoaViewModel
    {
       public User Usuario { get; set; }
       public IEnumerable<Pessoa> Pessoas { get; set; } 
    }
}