using System.ComponentModel.DataAnnotations;
using TiAchei_Tcc.Enums;

namespace TiAchei_Tcc.ViewModel
{
    public class PetViewModel
    {
        [Required(ErrorMessage = "Nome é obrigatorio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Raça é obrigatorio")]
        public string  Raca { get; set; }
        public IFormFile  Profile { get; set; }
        public bool Perdido { get; set; }
        public int CategoriaPetId { get; set; }
        public string  Descricao { get; set; }
    }
}