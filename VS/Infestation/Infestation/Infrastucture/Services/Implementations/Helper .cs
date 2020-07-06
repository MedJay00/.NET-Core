using Infestation.Infrastucture.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Infrastucture.Services
{
    public class Helper: IHelper
    {
        public String CreateCacheKey()
        {
           // return null;
            return $"image_{DateTime.UtcNow:yyyy_MM_dd}";
        }
    }
}