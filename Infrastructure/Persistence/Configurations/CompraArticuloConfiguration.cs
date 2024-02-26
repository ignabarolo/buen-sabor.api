
using buen_sabor.api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class CompraArticuloConfiguration : _BaseConfiguration<CompraArticulo>
{
    public override void Configure(EntityTypeBuilder<CompraArticulo> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Creado).IsRequired();
        builder.Property(p => p.Modificado).IsRequired();

        builder.HasOne(compraA => compraA.Articulo)
            .WithMany(articulo => articulo.CompraArticulos)
            .HasForeignKey(compraA => compraA.ArticuloId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
