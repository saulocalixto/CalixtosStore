using CalixtosStore.Data.Mapping;
using CalixtosStore.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CalixtosStore.Data.Context
{
    public class CalixtosStoreContext : DbContext
    {
        public CalixtosStoreContext(DbContextOptions<CalixtosStoreContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}