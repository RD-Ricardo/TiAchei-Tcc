namespace TiAchei_Tcc.Models
{
    public class CategoriaPessoa
    {
        public int  Id { get; set; }
        public string Nome { get; set; }
        public string  UserId { get; set; }
        public User Usuario { get; set; }
        public ICollection<Pessoa> Pessoas { get; set; }
    }   
}