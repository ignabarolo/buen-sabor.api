using Application.Common.Interfaces;
using Application.Interfaces;
using buen_sabor.api.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;
using System.Reflection;

namespace Infrastructure.Persistence
{
    public class AppDBContext : DbContext, IAppDBContext
    {
        private readonly IDateTime _dateTime;

        public AppDBContext(DbContextOptions<AppDBContext> options, IDateTime dateTime) : base(options)
        {
            #pragma warning disable EF1001 // Internal EF Core API usage.
            var ext = options.Extensions.FirstOrDefault(w => w.Info.IsDatabaseProvider) as NpgsqlOptionsExtension;
            _dateTime = dateTime;
            #pragma warning restore EF1001 // Internal EF Core API usage. }
        }

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

        public string GetVersion()
        {
            Database.GetDbConnection().Open();

            string ver = Database.GetDbConnection().ServerVersion;

            Database.GetDbConnection().Close();

            return ver;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        => await Database.BeginTransactionAsync();

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:

                        entry.Entity.Creado = _dateTime.Now;
                        entry.Entity.Modificado = _dateTime.Now;
                        entry.Entity.Habilitado = true;

                        break;
                    case EntityState.Modified:

                        entry.Entity.Modificado = _dateTime.Now;

                        break;
                    case EntityState.Deleted:

                        entry.State = EntityState.Modified;
                        entry.Entity.Modificado = _dateTime.Now;
                        entry.Entity.Habilitado = false;

                        break;
                }
            }
            var result = await base.SaveChangesAsync(cancellationToken);

            foreach (var entry in ChangeTracker.Entries().ToArray())
            {
                entry.State = EntityState.Detached;
            }

            return result;
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=172.0.0.161;Port=55433;Database=Metroin_Api;UserName=postgres;Password=Gl0bal2022123!;");
                optionsBuilder.UseLowerCaseNamingConvention();
            }
        }

        public async Task<int> ExecuteQuery(FormattableString query)
        {
            return await Database.SqlQuery<int>(query).FirstOrDefaultAsync();
        }



    }
}
