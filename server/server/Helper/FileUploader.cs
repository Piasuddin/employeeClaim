using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace server.Helper
{
    public static class FileUploader
    { 
        public static string Upload(string  file, string name, IWebHostEnvironment webHostEnvironment)
        {
            string fileName = Guid.NewGuid().ToString() + name.Substring(name.LastIndexOf('.'));
            string path = Path.Combine(webHostEnvironment.WebRootPath, "files", fileName);
            byte[] fileInByteArray = Convert.FromBase64String(file.Substring(file.LastIndexOf(',') + 1));
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                fileStream.Write(fileInByteArray, 0, fileInByteArray.Length);
            }
            return fileName;
        }
    }
}
