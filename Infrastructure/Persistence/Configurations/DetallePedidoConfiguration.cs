
using buen_sabor.api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class DetallePedidoConfiguration : _BaseConfiguration<DetallePedido>
{
    public override void Configure(EntityTypeBuilder<DetallePedido> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Creado).IsRequired();
        builder.Property(p => p.Modificado).IsRequired();

        builder.HasOne(detalleP => detalleP.Pedido)
            .WithMany(pedido => pedido.DetallesPedidos)
            .HasForeignKey(detalleP => detalleP.PedidoId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
