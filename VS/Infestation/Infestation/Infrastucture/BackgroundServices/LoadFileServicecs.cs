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
        private IExampleRestClient _restClient { get; }
        private IServiceProvider _scopeFactory { get; }//IServiceProvider
        public IHelper _helper { get; set; }
        InfestationConfiguration _infestationConfiguration { get; set; }

        public LoadFileServicecs(IMemoryCache cache, IExampleRestClient restClient, IOptions<InfestationConfiguration> options, IServiceProvider scopeFactory, IHelper helper)
        {
            _scopeFactory = scopeFactory;
            _cache = cache;
            _restClient = _scopeFactory.GetService<IExampleRestClient>();
            _helper = helper;
            _infestationConfiguration = options.Value;
            
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //using (var scope = _scopeFactory.CreateScope())
            //{
            //    var db = scope.ServiceProvider.GetRequiredService<IExampleRestClient>();
            //}


            while (!stoppingToken.IsCancellationRequested)
                {
                    var image = _restClient.GetFile();

                    if (image != null)
                    {
                        var cacheKey = $"image_{DateTime.UtcNow:yyyy_MM_dd}";

                        var entryOptions = new MemoryCacheEntryOptions();
                        entryOptions.SlidingExpiration = TimeSpan.FromMinutes(_infestationConfiguration.CacheTime);

                        _cache.Set<byte[]>(cacheKey, image, entryOptions);
                    }

                    await Task.Delay(TimeSpan.FromSeconds(30));

                }
            
            }
        
    }
}
