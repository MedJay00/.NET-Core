using Infestation.Infra.Services.Interfaces;
using Infestation.Infrastucture.Configuration;
using Infestation.Infrastucture.Services;
using Infestation.Infrastucture.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infestation.Infrastucture.BackgroundServices
{
    public class LoadFileServicecs : BackgroundService
    {
        private IMemoryCache _cache { get; }
        //private IExampleRestClient _restClient { get; }
        private IServiceProvider _scopeFactory { get; }//IServiceProvider  IServiceScopeFactory 
        public IHelper _helper { get; set; }
        InfestationConfiguration _infestationConfiguration { get; set; }

        public LoadFileServicecs(IMemoryCache cache, /*IExampleRestClient restClient,*/ IOptions<InfestationConfiguration> options, IServiceProvider scopeFactory, IHelper helper)
        {
            _scopeFactory = scopeFactory;
            _cache = cache;
            //_restClient = _scopeFactory.GetService<IExampleRestClient>();
            _helper = helper;
            _infestationConfiguration = options.Value;
            
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<IExampleRestClient>();

                while (!stoppingToken.IsCancellationRequested)
                {
                    var image = context.GetFile();


                    if (image != null)
                    {
                        var cacheKey = _helper.CreateCacheKey();

                        var entryOptions = new MemoryCacheEntryOptions();
                        entryOptions.SlidingExpiration = TimeSpan.FromMinutes(_infestationConfiguration.CacheTime);

                        _cache.Set<byte[]>(cacheKey, image, entryOptions);
                    }

                    var image_two = context.GetFile();
                    if (image != null)
                    {
                        var cacheKey_two = _helper.CreateCacheKey() + "2";

                        var entryOptions = new MemoryCacheEntryOptions();
                        entryOptions.SlidingExpiration = TimeSpan.FromMinutes(_infestationConfiguration.CacheTime);

                        _cache.Set<byte[]>(cacheKey_two, image, entryOptions);
                    }

                    await Task.Delay(TimeSpan.FromSeconds(30));

                }

            }
        }


           
        
    }
}
