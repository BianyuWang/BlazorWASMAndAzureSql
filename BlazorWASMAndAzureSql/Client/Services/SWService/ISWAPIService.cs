using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWASMAndAzureSql.Client.Services.SWService
{
    public interface ISWAPIService
    {
        Task<string> CallSWAPI(string url);
    }
}
