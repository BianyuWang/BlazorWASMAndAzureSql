using BlazorWASMAndAzureSql.Server.databases.DbContexts;
using BlazorWASMAndAzureSql.Server.Services;
using BlazorWASMAndAzureSql.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWASMAndAzureSql.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SWAPIController : ControllerBase
    {
        private readonly SWAPIClient _swapi;
       
        public SWAPIController(SWAPIClient SWAPI)
        {
            _swapi = SWAPI;
           
        }


        [HttpPost]
        public async Task <ActionResult> Post(hero hero)
        {
        
              var result= _swapi.CallSWAPI(hero.request);
            if (result != null)
                return Ok(result);

            return NotFound(result);
        }
    }
}
