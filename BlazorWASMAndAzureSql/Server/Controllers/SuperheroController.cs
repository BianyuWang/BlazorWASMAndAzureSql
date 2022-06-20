using AutoMapper;
using BlazorWASMAndAzureSql.Server.databases.DbContexts;
using BlazorWASMAndAzureSql.Server.databases.models;
using BlazorWASMAndAzureSql.Server.IService;
using BlazorWASMAndAzureSql.Server.Services;
using BlazorWASMAndAzureSql.Shared;
using BlazorWASMAndAzureSql.Shared.SWAPIModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWASMAndAzureSql.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SuperheroController : ControllerBase
    {

        
        private readonly SuperheroContext _dbcontext;
        private readonly IMapper _mapper;
        private readonly ISpeciesService _speciesService;
        private readonly IPeoplesService _peopleService;
        public SuperheroController(IPeoplesService peopleService,SuperheroContext dbcontext, IMapper mapper,ISpeciesService speciesService)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
            _speciesService = speciesService;
            _peopleService = peopleService;
        }

        [HttpPost]
        public async Task<string> InsertIntoDB(SuperheroEntity str)
        {
            switch(str.tableName)
            {
                case "species":
                    var outputSpe = JsonConvert.DeserializeObject<SWSpecies>(str.jsonStr);
                    var sp = _mapper.Map<Species>(outputSpe);
                    await _speciesService.InsertAsync(sp);
                    break;
                case "people":
                    var outputPeo = JsonConvert.DeserializeObject<SWPeople>(str.jsonStr);
                    var pl = _mapper.Map<Peoples>(outputPeo);
                    await _peopleService.InsertAsync(pl);
                    break;
            }

          
            return "done";
        }

      
    }
}
