using TiAchei_Tcc.Models;
using TiAchei_Tcc.ViewModel;

namespace TiAchei_Tcc.Services
{
    public class ServiceUploadFile
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ServiceUploadFile(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public string UploadFile(RegisterViewModel vm)
        {
            string file = null;
            if(vm.Profile != null)
            {
                string upLoadDir =  Path.Combine(_webHostEnvironment.WebRootPath,"Imagens");
                file = Guid.NewGuid().ToString()+"-"+ vm.Profile.FileName;
                string filePath = Path.Combine(upLoadDir, file);

                using(var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    vm.Profile.CopyTo(fileStream);
                }
            }
            return file;   
        }

        public string UploadFilePet(PetViewModel vm)
        {
            string file = null;
            if(vm.Profile != null)
            {
                string upLoadDir =  Path.Combine(_webHostEnvironment.WebRootPath,"ImgPets");
                file = Guid.NewGuid().ToString()+"-"+ vm.Profile.FileName;
                string filePath = Path.Combine(upLoadDir, file);

                using(var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    vm.Profile.CopyTo(fileStream);
                }
            }
            return file;   
        }
    }
}