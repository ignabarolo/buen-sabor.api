using buen_sabor.api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class DomicilioConfiguration : _BaseConfiguration<Domicilio>
{
    public override void Configure(EntityTypeBuilder<Domicilio> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Creado).IsRequired();
        builder.Property(p => p.Modificado).IsRequired();

        builder.HasOne(domicilio => domicilio.Usuario)
            .WithMany(usuario => usuario.Domicilios)
            .HasForeignKey(domicilio => domicilio.UsuarioId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
