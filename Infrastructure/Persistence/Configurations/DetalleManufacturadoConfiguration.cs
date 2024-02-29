
using buen_sabor.api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class DetalleManufacturadoConfiguration : _BaseConfiguration<DetalleManufacturado>
{

    public override void Configure(EntityTypeBuilder<DetalleManufacturado> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Creado).IsRequired();
        builder.Property(p => p.Modificado).IsRequired();

        //builder.HasOne(detalleM => detalleM.Articulo)
        //    .WithOne(articulo => articulo.DetalleManufacturado)
        //    .HasForeignKey<Articulo>(h => h.DetalleManufacturadoId)
        //    .IsRequired(false);

        builder.HasOne(detalleM => detalleM.Manufacturado)
            .WithMany(manufacturado => manufacturado.DetallesManufacturado)
            .HasForeignKey(detalleM => detalleM.ManufacturadoId)
            .OnDelete(DeleteBehavior.ClientSetNull);

    }
}
