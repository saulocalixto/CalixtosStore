using CalixtosStore.Application.Dtos;
using CalixtosStore.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace CalixtosStore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Cliente : ControllerBase
    {
        private readonly IClienteService _service;

        public Cliente(IClienteService service)
        {
            _service = service;
        }

        [HttpPost]
        public void Registrar([FromBody] ClienteDto cliente)
        {
            _service.Registrar(cliente);

            Response.StatusCode = (int)HttpStatusCode.OK;
        }

        [HttpPut]
        public void Atualizar([FromBody] ClienteDto cliente)
        {
            _service.Atualizar(cliente);

            Response.StatusCode = (int)HttpStatusCode.OK;
        }

        [HttpDelete]
        public void Remover(Guid idCliente)
        {
            _service.Remover(idCliente);

            Response.StatusCode = (int)HttpStatusCode.OK;
        }
    }
}