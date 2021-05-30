using AutoMapper;
using CalixtosStore.Application.Dtos;
using CalixtosStore.Application.Interface;
using CalixtosStore.Domain.Commands;
using CalixtosStore.Domain.Core.Bus;
using System;
using System.Collections.Generic;

namespace CalixtosStore.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;

        //private readonly ICustomerRepository _customerRepository;
        //private readonly IEventStoreRepository _eventStoreRepository;

        public ClienteService(IMapper mapper,
                                  IMediatorHandler bus)
        {
            _mapper = mapper;
            _bus = bus;
        }

        public void Atualizar(ClienteDto customerViewModel)
        {
            var commandoAtualizar = _mapper.Map<AtualizarClienteCommand>(customerViewModel);
            _bus.SendCommand(commandoAtualizar);
        }

        public IEnumerable<ClienteDto> Listar()
        {
            throw new NotImplementedException();
        }

        public ClienteDto ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Registrar(ClienteDto clienteDto)
        {
            var comandoRegistro = _mapper.Map<RegistrarNovoClienteCommand>(clienteDto);
            _bus.SendCommand(comandoRegistro);
        }

        public void Remover(Guid id)
        {
            var comandoRemover = new RemoverClienteCommand(id);
            _bus.SendCommand(comandoRemover);
        }
    }
}