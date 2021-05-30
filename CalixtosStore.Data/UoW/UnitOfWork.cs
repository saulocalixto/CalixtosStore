using CalixtosStore.Data.Context;
using CalixtosStore.Domain.Interfaces;

namespace CalixtosStore.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CalixtosStoreContext _context;

        public UnitOfWork(CalixtosStoreContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}