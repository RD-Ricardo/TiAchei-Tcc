using Microsoft.AspNetCore.Mvc;
using TiAchei_Tcc.ViewModel;

namespace TiAchei_Tcc.Extensions
{
    public static class ControllerExtensions
    {
        public static void MostrarMensagem(this Controller @this, string texto, TipoMensagem type)
            => @this.TempData["mensagem"] = MensagemViewModel.Serializar(texto, type);
        
    }
}