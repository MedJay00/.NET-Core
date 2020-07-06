using Infestation.Infrastucture.Services.Implementations;
using Infestation.Infrastucture.Services.Interfaces;
using Infestation.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Infestation.Controllers
{
    public class TerrainController : Controller
    {
        private IMemoryCache _cache { get; }
        private IExampleRestClient _restClient { get; }
        private IFileProcessingChannel _channel { get; }
        private IHelper _Helper { get; }


        public TerrainController(IMemoryCache cache, IExampleRestClient restClient, IFileProcessingChannel channel, IHelper Helper)
        {
            _cache = cache;
            _restClient = restClient;
            _channel = channel;
            _Helper = Helper;
        }

        [AllowAnonymous]
        public FileContentResult Image()
        {
            var cacheKey = _Helper.CreateCacheKey();
            var image = _cache.Get<byte[]>(cacheKey);
            if (image == null)
            {
                var entryOptions = new MemoryCacheEntryOptions();
                entryOptions.SlidingExpiration = TimeSpan.FromMinutes(2);

                image = _restClient.GetFile();
                _cache.Set<byte[]>(cacheKey, image, entryOptions);
            }

            return new FileContentResult(image, "image/jpeg");
        }

        [AllowAnonymous]
        public IActionResult Upload()
        {
            
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Upload(TerrainUploadViewModel uploadViewModel)
        {
            if (uploadViewModel.File?.Length > 0)
            {
                await _channel.SetAsync(uploadViewModel.File);

                //uploadViewModel.
            }

            
            return View(uploadViewModel);
        }

    }
}
