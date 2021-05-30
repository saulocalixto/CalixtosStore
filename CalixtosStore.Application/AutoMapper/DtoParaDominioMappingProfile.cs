using AutoMapper;
using CalixtosStore.Application.Dtos;
using CalixtosStore.Domain.Commands;

namespace CalixtosStore.Application.AutoMapper
{
    public class DtoParaDominioMappingProfile : Profile
    {
        public DtoParaDominioMappingProfile()
        {
            CreateMap<ClienteDto, RegistrarNovoClienteCommand>()
                .ConstructUsing(c => new RegistrarNovoClienteCommand(c.Nome, c.Email, c.DataDeNascimento));
            CreateMap<ClienteDto, AtualizarClienteCommand>()
                .ConstructUsing(c => new AtualizarClienteCommand(c.Id, c.Nome, c.Email, c.DataDeNascimento));
        }
    }
}