using TiAchei_Tcc.Enums;

namespace TiAchei_Tcc.ViewModel
{
    public class PessoaViewModel
    {
       public string  Nome { get; set; } 
       public int Idade { get; set; }
       public bool  Perdida { get; set; }
       public CategoriaPessoa Categoria { get; set; }
       public string  Descricao { get; set; }
       public IFormFile Profile { get; set; }
       public int EnfermidadePessoaId { get; set; }
    }
}