using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Pri.WebApi.Food.Core.Services.Models;

namespace Pri.WebApi.Food.Core.Services.Interfaces
{
    public interface IImageService
    {
        Task<ResultModel<string>> AddOrUpdateImageAsync(IFormFile image, string fileName = "");
    }
}
