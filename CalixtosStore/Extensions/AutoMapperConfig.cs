using CalixtosStore.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using AutoMapper;

namespace CalixtosStore.Extensions
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DominioParaDtoMappingProfile), typeof(DtoParaDominioMappingProfile));
        }
    }
}