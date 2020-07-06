using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Infrastucture.Services.Interfaces
{
   public interface IFileProcessingChannel
    {
      
        public Task SetAsync(IFormFile file);
        public IAsyncEnumerable<IFormFile> GetAllAsync();
        public void Set(IFormFile file);
        public IFormFile Get();

    }
}
