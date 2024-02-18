using Application.Common.Interfaces;
using buen_sabor.api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;

namespace Infrastructure.Persistence
{
    public class AppDBContext : DbContext, IAppDBContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {}

        public DbSet<Domicilio> Domicilio { get; set; }

        public string GetVersion()
        {
            Database.GetDbConnection().Open();

            string ver = Database.GetDbConnection().ServerVersion;
                
            Database.GetDbConnection().Close();

            return ver;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        => await Database.BeginTransactionAsync();

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken) => throw new NotImplementedException();

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
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=buen_sabor;UserName=ibarolo;Password=pass2024!;");
            }

        }

        public async Task<int> ExecuteQuery(FormattableString query)
        {
            return await Database.SqlQuery<int>(query).FirstOrDefaultAsync();
        }

        

    }
}
