using Microsoft.AspNetCore.Mvc;
using TiAchei_Tcc.Services;

namespace TiAchei_Tcc.Controllers
{
    public class ImgQrCodeController : Controller
    {
        [HttpGet]
        public IActionResult Index(string id)
            => File(GeneratorQrCode.GenerateByteArray($"https://{HttpContext.Request.Host.Value}/card/perfil/{id}"), "image/jpeg");    
        [HttpGet]
        public IActionResult Pessoa(string id)
            => File(GeneratorQrCode.GenerateByteArray($"https://{HttpContext.Request.Host.Value}/card/perfilpessoa/{id}"), "image/jpeg");    
    }
}