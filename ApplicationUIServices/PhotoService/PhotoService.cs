using ApplicationUIServices.PhotoService.Abstraction;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationUIServices.PhotoService
{
    public class PhotoService : IPhotoService
    {
        public static IWebHostEnvironment _environment;
        public PhotoService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public async Task<string> AddPhoto(IFormFile Image)
        {
            try
            {
                if(Image != null) {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Images\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Images\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Images\\" + Image.FileName))
                    {
                        Image.CopyToAsync(fileStream);
                        fileStream.Flush();
                        return _environment.WebRootPath + "\\Images\\" + Image.FileName;
                    }
                }
                else
                {
                    return null;
                }


            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
