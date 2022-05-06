namespace TiAchei_Tcc.Models
{
    public class Pet
    {
        public Pet()
        {
            Id = new Guid();
            DataCricao = DateTime.Now;       
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string  Foto { get; set; }
        public bool Perdido { get; set; }
        public DateTime DataCricao { get; set; }
        public string  Descricao { get; set; }
        public string  UserId { get; set; }
        public User Usuario { get; set; }
    }
}