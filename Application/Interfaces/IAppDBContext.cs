using buen_sabor.api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Application.Common.Interfaces
{
    public interface IAppDBContext
    {
        public DbSet<Domicilio> Domicilio { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Pedido> Pedido { get; set; }

        public DbSet<Efectivo> Efectivo { get; set; }

        public DbSet<MercadoPago> MercadoPago { get; set; }

        public DbSet<DetallePedido> DetallePedido { get; set; }

        public DbSet<Manufacturado> Manufacturado { get; set; }

        public DbSet<DetalleManufacturado> DetalleManufacturado { get; set; }

        public DbSet<Articulo> Articulo { get; set; }

        public DbSet<Rubro> Rubro { get; set; }

        public DbSet<CompraArticulo> CompraArticulo { get; set; }

        public string GetVersion();

        public Task<int> ExecuteQuery(FormattableString query);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
    }
}
