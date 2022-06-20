using Autofac;
using BlazorWASMAndAzureSql.Server.IRepositories.IBaseRepositories;
using BlazorWASMAndAzureSql.Server.IService;
using BlazorWASMAndAzureSql.Server.Repositories.BaseRepositories;
using BlazorWASMAndAzureSql.Server.Services;
using BlazorWASMAndAzureSql.Server.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BlazorWASMAndAzureSql.Server.Services.ServiceExtension
{
    public class AutoFacModuleRegister: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(BaseServices<>)).As(typeof(IBaseService<>)).InstancePerDependency();

            var assemblysServices = Assembly.Load("BlazorWASMAndAzureSql.Server"); //important!!! not interface
            builder.RegisterAssemblyTypes(assemblysServices).AsImplementedInterfaces();

            //var assemblysRepository = Assembly.Load("BlazorWASMAndAzureSql.Server.Repositories");
            //builder.RegisterAssemblyTypes(assemblysRepository)
            //    .AsImplementedInterfaces();
        }
    }
}
