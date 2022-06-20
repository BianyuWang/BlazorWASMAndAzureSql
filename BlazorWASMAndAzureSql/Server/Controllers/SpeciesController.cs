using AutoMapper;
using BlazorWASMAndAzureSql.Server.databases.DbContexts;
using BlazorWASMAndAzureSql.Server.databases.models;
using BlazorWASMAndAzureSql.Server.IService;
using BlazorWASMAndAzureSql.Shared;
using BlazorWASMAndAzureSql.Shared.SWAPIModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWASMAndAzureSql.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeciesController : Controller
    {
        private readonly SuperheroContext _dbcontext;
        private readonly IMapper _mapper;

        private readonly ISpeciesService _speciesService;
        public SpeciesController(ISpeciesService speciesService, SuperheroContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
            _speciesService = speciesService;
        }
        [HttpPost]
        public async Task<ActionResult> InsertIntoDBAsync(SuperheroEntity str)
        {
            var outputPeo = JsonConvert.DeserializeObject<SWSpecies>(str.jsonStr);
            var pl = _mapper.Map<Species>(outputPeo);
            pl = await _speciesService.InsertAsync(pl);
            return Ok(pl);
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _speciesService.GetListAsync());
        }
    }
}
