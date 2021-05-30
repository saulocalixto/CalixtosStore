using System;
using System.Linq;

namespace CalixtosStore.Domain.Interfaces
{
    public interface IRepositorio<TEntity> : IDisposable where TEntity : class
    {
        void Adicionar(TEntity obj);

        TEntity ObterPorId(Guid id);

        IQueryable<TEntity> Listar();

        void Atualizar(TEntity obj);

        void Remover(Guid id);

        int SaveChanges();
    }
}