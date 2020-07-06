﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Infrastucture.Services.Interfaces
{
    public interface IExampleRestClient
    {
        byte[] GetFile();
        byte[] GetFile_two();
        void UploadFile(IFormFile file);
    }
}
