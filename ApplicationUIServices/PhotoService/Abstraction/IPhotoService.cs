using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationUIServices.PhotoService.Abstraction
{
    public interface IPhotoService
    {
        public Task<string> AddPhoto(IFormFile Image);
    }
}
