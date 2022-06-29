namespace TiAchei_Tcc.Models
{
    public class EnfermidadePessoa
    {
        public string  Id { get; set; } = Guid.NewGuid().ToString();
        public string Nome { get; set; }
        public string  UserId { get; set; }
        public User Usuario { get; set; }
        public ICollection<Pessoa> Pessoas { get; set; }
    }   
}