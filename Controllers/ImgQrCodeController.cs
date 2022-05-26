using Microsoft.AspNetCore.Mvc;
using TiAchei_Tcc.Services;

namespace TiAchei_Tcc.Controllers
{
    public class ImgQrCodeController : Controller
    {
        public ImgQrCodeController()
        {
            
        }

        [HttpGet]
        public IActionResult Index(string id)
        {
            var url = $"https://{HttpContext.Request.Host.Value}/card/perfil/{id}";
            var image = GeneratorQrCode.GenerateByteArray(url);
            return File(image, "image/jpeg");
        }
    }
}