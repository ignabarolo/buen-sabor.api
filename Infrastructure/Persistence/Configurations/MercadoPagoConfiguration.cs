
using buen_sabor.api.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class MercadoPagoConfiguration : _BaseConfiguration<MercadoPago>
{
    public override void Configure(EntityTypeBuilder<MercadoPago> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Creado).IsRequired();
        builder.Property(p => p.Modificado).IsRequired();
    }
}
