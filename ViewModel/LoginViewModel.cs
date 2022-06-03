using System.ComponentModel.DataAnnotations;

namespace TiAchei_Tcc.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email Obrigatorio")]
        public string  Email { get; set; }
        [Required(ErrorMessage ="Senha Obrigatorio")]
        [DataType(DataType.Password)]
        public string  Senha { get; set; }
        public string ReturnUrl { get; set; }
    }
}