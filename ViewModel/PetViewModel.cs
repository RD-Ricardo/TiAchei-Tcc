using TiAchei_Tcc.Enums;

namespace TiAchei_Tcc.ViewModel
{
    public class PetViewModel
    {
        public string Nome { get; set; }
        public string  Raca { get; set; }
        public IFormFile  Profile { get; set; }
        public bool Perdido { get; set; }
        public Tipo Tipo { get; set; }
        public string  Descricao { get; set; }
    }
}