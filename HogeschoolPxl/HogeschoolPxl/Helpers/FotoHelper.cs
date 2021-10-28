using HogeschoolPxl.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPxl.Helpers
{
    public class FotoHelper
    {
        private readonly IWebHostEnvironment hostingEnvironment;

        public FotoHelper(IWebHostEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }
        public void DeleteExistingPhoto(string uniqueUrl)
        {
            //delete existing photo
            string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images",uniqueUrl);
            System.IO.File.Delete(filePath);
        }
        public string ProcessUploadedFile(HandboekCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                //upload de image file to the server (images folder)
                using FileStream fs = new FileStream(filePath, FileMode.Create);
                model.Photo.CopyTo(fs);
            }
            return uniqueFileName;
        }
        public string ProcessUploadedFile(GebruikerCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                //upload de image file to the server (images folder)
                using FileStream fs = new FileStream(filePath, FileMode.Create);
                model.Photo.CopyTo(fs);
            }
            return uniqueFileName;
        }
    }
}
