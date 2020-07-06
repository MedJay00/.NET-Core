 using Infestation.Infrastucture.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Infestation.Infrastucture.Services.Implementations
{
    public class FileProcessingChannel: IFileProcessingChannel
    {

        private Channel<IFormFile> _channel;

        public FileProcessingChannel()
        {
            _channel = Channel.CreateUnbounded<IFormFile>();
        }

        public async Task SetAsync(IFormFile file)
        {
            await _channel.Writer.WriteAsync(file);
        }

        public IAsyncEnumerable<IFormFile> GetAllAsync()
        {
            return _channel.Reader.ReadAllAsync();
        }

        public void Set(IFormFile file)
        {
            _channel.Writer.TryWrite(file);
        }

        public IFormFile Get()
        {
            _channel.Reader.TryRead(out IFormFile file);
            return file;
        }
    }
}
