using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Pri.WebApi.Food.Core.Services.Interfaces;
using Pri.WebApi.Food.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.WebApi.Food.Core.Services
{
    public class ImageService : IImageService
    {
        private readonly IHostEnvironment _hostEnvironment;

        public ImageService(IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        public async Task<ResultModel<string>> AddOrUpdateImageAsync
           (IFormFile image, string fileName = "")
        {
            if (fileName == "")
            {
                fileName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
            }

            var pathOnDisk = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot",
                      "img", "food");

            if (!Directory.Exists(pathOnDisk))
            {
                Directory.CreateDirectory(pathOnDisk);
            }

            var completePathWithFilename = Path.Combine(pathOnDisk, fileName);


            using (FileStream fileStream = new(completePathWithFilename, FileMode.Create))
            {
                try
                {
                    await image.CopyToAsync(fileStream);
                    return new ResultModel<string>
                    {
                        Data = fileName
                    };
                }
                catch (FileNotFoundException exception)
                {
                    return new ResultModel<string>
                    {
                        Errors = new List<string> { exception.Message }
                    };
                }
            }
        }
    }

}
