using BlazorWASMAndAzureSql.Server.databases.models;
using BlazorWASMAndAzureSql.Server.IRepositories;
using BlazorWASMAndAzureSql.Server.IService;
using BlazorWASMAndAzureSql.Server.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWASMAndAzureSql.Server.Services
{
    public class PeoplesService : BaseServices<Peoples>, IPeoplesService
    {
        private readonly IPeopleRepository _PeopleRepository;
        public PeoplesService(IPeopleRepository PeopleRepository) :base(PeopleRepository)
        {
            _PeopleRepository = PeopleRepository;
        }
    }
}
