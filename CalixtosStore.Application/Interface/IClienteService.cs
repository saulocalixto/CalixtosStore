using CalixtosStore.Application.Dtos;
using System;
using System.Collections.Generic;

namespace CalixtosStore.Application.Interface
{
    public interface IClienteService
    {
        void Registrar(ClienteDto clienteDto);

        IEnumerable<ClienteDto> Listar();

        ClienteDto ObterPorId(Guid id);

        void Atualizar(ClienteDto customerViewModel);

        void Remover(Guid id);
    }
}