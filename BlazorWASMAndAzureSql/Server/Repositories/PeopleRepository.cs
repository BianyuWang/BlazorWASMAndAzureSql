using BlazorWASMAndAzureSql.Server.Repositories.BaseRepositories;
using BlazorWASMAndAzureSql.Server.databases.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorWASMAndAzureSql.Server.databases.DbContexts;
using BlazorWASMAndAzureSql.Server.IRepositories;

namespace BlazorWASMAndAzureSql.Server.Repositories
{
    public class PeopleRepository : BaseRepository<Peoples>, IPeopleRepository
    {
        public PeopleRepository(SuperheroContext context) : base(context)
        {

        }
    }
}
