using TiAchei_Tcc.Enums;
namespace TiAchei_Tcc.Models
{
    public class Pessoa 
    {
       public string Id { get; set; } = Guid.NewGuid().ToString();
       public string  Nome { get; set; } 
       public int Idade { get; set; }
       public bool  Perdido { get; set; }
       public string  Descricao { get; set; }
       public string  FotoUrl { get; set; }
       public string  UserId { get; set; }
       public User Usuario { get; set; }
       public CategoriaPessoa Categoria { get; set; }
       public DateTime DataCriacao { get; set; }
       public string EnfermidadePessoaId { get; set; }
       public EnfermidadePessoa EnfermidadePessoa { get; set; }
    }
}