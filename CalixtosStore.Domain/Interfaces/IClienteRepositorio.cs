using CalixtosStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalixtosStore.Domain.Interfaces
{
    public interface IClienteRepositorio : IRepositorio<Cliente>
    {
        Cliente GetByEmail(string email);
    }
}