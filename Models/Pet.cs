using System.ComponentModel.DataAnnotations;

namespace TiAchei_Tcc.Models
{
    public class Pet
    {
        [Key]
        public string  Id { get; set; } = Guid.NewGuid().ToString();
        public string Nome { get; set; }
        public string  Raca { get; set; }
        public string  Foto { get; set; }
        public bool Perdido { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime DataCricao { get; set; } = DateTime.Now;
        public string  Descricao { get; set; }
        public int CategoriaPetId { get; set; }
        public CategoriaPet Categoria { get; set; }
        public string  UserId { get; set; }
        public User Usuario { get; set; }
    }
}