
using buen_sabor.api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ManufacturadoConfiguration : _BaseConfiguration<Manufacturado>
{
    public override void Configure(EntityTypeBuilder<Manufacturado> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Creado).IsRequired();
        builder.Property(p => p.Modificado).IsRequired();

        builder.HasOne(manufacturado => manufacturado.Rubro)
            .WithMany(rubro => rubro.Manufacturados)
            .HasForeignKey(manufacturado => manufacturado.RubroId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(manufacturado => manufacturado.DetallePedido)
            .WithOne(detalleP => detalleP.Manufacturado)
            .HasForeignKey<DetallePedido>(h => h.ManufacturadoId)
            .IsRequired(false);
    }
}
