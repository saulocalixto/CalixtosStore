using AutoMapper;
using CalixtosStore.Application.Dtos;
using CalixtosStore.Domain.Models;

namespace CalixtosStore.Application.AutoMapper
{
    public class DominioParaDtoMappingProfile : Profile
    {
        public DominioParaDtoMappingProfile()
        {
            CreateMap<Cliente, ClienteDto>();
        }
    }
}