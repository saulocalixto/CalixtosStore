using CalixtosStore.Data.Context;
using CalixtosStore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CalixtosStore.Data.Repository
{
    public class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : class
    {
        protected readonly CalixtosStoreContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repositorio(CalixtosStoreContext db)
        {
            try
            {
                Db = db;
                DbSet = Db.Set<TEntity>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Adicionar(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public void Atualizar(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<TEntity> Listar()
        {
            return DbSet;
        }

        public TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public void Remover(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
    }
}