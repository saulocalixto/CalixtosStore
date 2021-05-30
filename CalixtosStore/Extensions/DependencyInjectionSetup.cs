using CalixtosStore.Infra.CossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CalixtosStore.Extensions
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            CalixtosStoreIoC.RegisterServices(services);
        }
    }
}