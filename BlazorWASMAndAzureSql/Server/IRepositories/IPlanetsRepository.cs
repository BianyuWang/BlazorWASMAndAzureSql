using BlazorWASMAndAzureSql.Server.databases.models;
using BlazorWASMAndAzureSql.Server.IRepositories.IBaseRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWASMAndAzureSql.Server.IRepositories
{
    public interface IPlanetsRepository : IBaseRepository<Planets>
    {
    }
}
