using buen_sabor.api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ArticuloConfiguration : _BaseConfiguration<Articulo>
{
    public override void Configure(EntityTypeBuilder<Articulo> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.RubroId).IsRequired();
        builder.Property(p => p.Creado).IsRequired();
        builder.Property(p => p.Modificado).IsRequired();

        builder.HasOne(articulo => articulo.Rubro)
            .WithMany(rubro => rubro.Articulos)
            .HasForeignKey(articulo => articulo.RubroId)
            .OnDelete(DeleteBehavior.ClientSetNull);
        
        builder.HasOne(articulo => articulo.DetallePedido)
            .WithMany(detalleP => detalleP.Articulos)
            .HasForeignKey(articulo => articulo.DetallePedidoId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(articulo => articulo.DetalleManufacturado)
            .WithOne(detalleM => detalleM.Articulo)
            .HasForeignKey<DetalleManufacturado>(h => h.ArticuloId)
            .IsRequired(true);
    }
}
