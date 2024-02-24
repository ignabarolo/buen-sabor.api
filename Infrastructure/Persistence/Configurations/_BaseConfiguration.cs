using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations;

public abstract class _BaseConfiguration<T> : IEntityTypeConfiguration<T>
where T : class
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
    }
}
