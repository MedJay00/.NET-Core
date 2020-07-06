 
using Infestation.Infrastucture.Services.Implementations;
using Infestation.Infrastucture.Services.Interfaces;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infestation.Infrastructure.BackgroundServices
{
    public class UploadFileService : BackgroundService
    {
        private IFileProcessingChannel _channel { get; }
        private IExampleRestClient _restClient { get; }


        public UploadFileService(IFileProcessingChannel channel, IExampleRestClient restClient)
        {
            _channel = channel;
            _restClient = restClient;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await foreach (var file in _channel.GetAllAsync())
            {
                _restClient.UploadFile(file);
            }
        }
    }
}

