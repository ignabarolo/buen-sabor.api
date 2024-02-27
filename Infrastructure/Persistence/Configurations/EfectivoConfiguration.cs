
using buen_sabor.api.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class EfectivoConfiguration : _BaseConfiguration<Efectivo>
{
    public override void Configure(EntityTypeBuilder<Efectivo> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Creado).IsRequired();
        builder.Property(p => p.Modificado).IsRequired();
    }
}
