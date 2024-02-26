
using buen_sabor.api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class PedidoConfiguration : _BaseConfiguration<Pedido>
{
    public override void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Creado).IsRequired();
        builder.Property(p => p.Modificado).IsRequired();

        builder.HasOne(pedido => pedido.Efectivo)
            .WithOne(efectivo =>  efectivo.Pedido)
            .HasForeignKey<Efectivo>(h => h.PedidoId)
            .IsRequired(false);
        
        builder.HasOne(pedido => pedido.MercadoPago)
            .WithOne(mp => mp.Pedido)
            .HasForeignKey<MercadoPago>(h => h.PedidoId)
            .IsRequired(false);
        
        builder.HasOne(pedido => pedido.Usuario)
            .WithMany(usuario => usuario.Pedido)
            .HasForeignKey(pedido => pedido.UsuarioId)
            .OnDelete(DeleteBehavior.ClientSetNull);

    }
}
