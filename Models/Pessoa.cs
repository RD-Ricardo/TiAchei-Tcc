namespace TiAchei_Tcc.Models
{
    public class Pessoa 
    {
       public string Id { get; set; } = Guid.NewGuid().ToString();
       public string  Nome { get; set; } 
       public int Idade { get; set; }
       public bool  Perdida { get; set; }
       public string  Descricao { get; set; }
    }
}