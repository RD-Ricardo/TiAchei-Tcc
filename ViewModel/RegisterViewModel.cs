using System.ComponentModel.DataAnnotations;

namespace TiAchei_Tcc.Models{

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email obrigatorio.")]
        public string  Email { get; set; }
        [Required(ErrorMessage = "Senha Obrigatorio")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Nome Obrigatorio")]
        public string Nome { get; set; }
        public IFormFile Profile { get; set; }
        [Required(ErrorMessage = "Telefone Obrigatorio")]
        public string  Telefone { get; set; }
        public string  UrlFacebook { get; set; }
        public string  UrlInstagram { get; set; }
    }

}