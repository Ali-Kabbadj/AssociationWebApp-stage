using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClinic.Classes.UploadFiles
{
    public class Upload
    {
        private readonly IWebHostEnvironment _environment;
        public Upload(IWebHostEnvironment Environment)
        {
            _environment = Environment;
        }

        // Method UploadFile-- return fileName And Add Image To Profiles Folder -- Profiles Dir is in WWWRoot Folder
        public string Image(IFormFile image)
        {
            string fileName = null;
            if (image != null)
            {
                string UploadDir = Path.Combine(_environment.WebRootPath, "Images/Home");
                fileName = Guid.NewGuid().ToString() + "-" + image.FileName;
                string filePath = Path.Combine(UploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
            }
            return fileName;
        }
    }
}
