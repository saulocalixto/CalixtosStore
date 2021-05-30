using CalixtosStore.Data.Context;
using CalixtosStore.Domain.Interfaces;
using CalixtosStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalixtosStore.Data.Repository
{
    public class ClienteRepositorio : Repositorio<Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(CalixtosStoreContext db) : base(db)
        {
        }

        public Cliente GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        }
    }
}