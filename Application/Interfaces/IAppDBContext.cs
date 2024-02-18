using buen_sabor.api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Application.Common.Interfaces
{
    public interface IAppDBContext
    {
        public DbSet<Domicilio> Domicilio { get; set; }

        public string GetVersion();

        public Task<int> ExecuteQuery(FormattableString query);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
    }
}
