using System.Reflection;
using Autofac;
using GieldaL2.DB.Interfaces;
using GieldaL2.INFRASTRUCTURE.Interfaces;
using GieldaL2.INFRASTRUCTURE.Mappers;

namespace GieldaL2.INFRASTRUCTURE.IoC
{
    /// <summary>
    /// Class that contains Dependency Injection configuration
    /// </summary>
    public class ContainerModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(ContainerModule)
               .GetTypeInfo()
               .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IRepository>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IService>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            MapperConfig.Init();
        }
    }
}
