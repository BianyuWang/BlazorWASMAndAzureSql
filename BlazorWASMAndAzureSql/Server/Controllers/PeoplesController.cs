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
    public class PeoplesController : ControllerBase
    {

        private readonly SuperheroContext _dbcontext;
        private readonly IMapper _mapper;

        private readonly IPeoplesService _peopleService;
        public PeoplesController(IPeoplesService peopleService, SuperheroContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
            _peopleService = peopleService;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFromDatabase(int Id)
        {
          int idDeleted = await  _peopleService.DeleteAsync(x => x.Id == Id);
            if (idDeleted != 0)
                return Ok(idDeleted);
            else
                return BadRequest(idDeleted);
        }
        [HttpPost]
        public async Task<ActionResult> InsertIntoDBAsync(SuperheroEntity str)
        {
            var outputPeo = JsonConvert.DeserializeObject<SWPeople>(str.jsonStr);
            var pl = _mapper.Map<Peoples>(outputPeo);
            pl=  await _peopleService.InsertAsync(pl);
            return Ok(pl);
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _peopleService.GetListAsync());
        }

    }
}
