using AutoMapper;
using BlazorWASMAndAzureSql.Server.databases.DbContexts;
using BlazorWASMAndAzureSql.Server.databases.models;
using BlazorWASMAndAzureSql.Server.IService;
using BlazorWASMAndAzureSql.Shared;
using BlazorWASMAndAzureSql.Shared.SWAPIModels;
using Microsoft.AspNetCore.Http;
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
    public class PlanetsController : ControllerBase
    {
        
        private readonly SuperheroContext _dbcontext;
        private readonly IMapper _mapper;

        private readonly IPlanetsService _planetsService;
          public PlanetsController (IPlanetsService planetsService, SuperheroContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
            _planetsService = planetsService;
        }
        [HttpPost]
        public async Task<ActionResult> InsertIntoDBAsync(SuperheroEntity str)
        {
            var outputPeo = JsonConvert.DeserializeObject<SWPlanet>(str.jsonStr);
            var pl = _mapper.Map<Planets>(outputPeo);
            pl = await _planetsService.InsertAsync(pl);
            return Ok(pl);
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _planetsService.GetListAsync());
        }
    }
}
