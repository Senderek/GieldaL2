using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using GieldaL2.DB.Interfaces;

namespace GieldaL2.INFRASTRUCTURE.IoC
{
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
        }
    }
}
