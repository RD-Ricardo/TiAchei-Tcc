using Microsoft.AspNetCore.Mvc;
using TiAchei_Tcc.Services;

namespace TiAchei_Tcc.Controllers
{
    public class QrcodeController : Controller
    {
        public QrcodeController()
        {
            
        }

        [HttpGet]
        public IActionResult Index()
        {
            var image = GeneratorQrCode.GenerateByteArray("");
            return File(image, "image/jpeg");
        }
    }
}