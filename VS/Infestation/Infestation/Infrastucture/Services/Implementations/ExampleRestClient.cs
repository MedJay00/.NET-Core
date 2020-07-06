using Infestation.Infrastucture.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Infrastucture.Services.Implementations
{
    public class ExampleRestClient : IExampleRestClient
    {
        public byte[] GetFile()
        {
            var client = new RestClient("http://localhost:54196");

            var reqest = new RestRequest("File", Method.GET);

            var result=client.Execute(reqest).RawBytes;

            return result;
        }
        public byte[] GetFile_two()
        {
            var client = new RestClient("http://localhost:54196");

            var reqest = new RestRequest("File_two", Method.GET);

            var result = client.Execute(reqest).RawBytes;

            return result;
        }

        public void UploadFile(IFormFile file)
        {
            var client = new RestClient("http://localhost:54196");
            var request = new RestRequest("File", Method.POST);
            if (file != null)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var imageBytes = ms.ToArray();
                    request.AddJsonBody(Convert.ToBase64String(imageBytes));
                }

                request.AddQueryParameter("fileName", file.FileName);
                client.Execute(request);
            }
        }
    }
}
