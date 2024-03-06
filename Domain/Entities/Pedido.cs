using buen_sabor.api.Enums;
using Domain.Entities;

namespace buen_sabor.api.Entities;

public class Pedido : BaseEntity
{
    public TimeSpan HoraEstimada { get; set; }

    public bool Retirolocal { get; set; }
    
    public int Descuento { get; set; }
    
    public Guid UsuarioId { get; set; }

    public virtual Usuario Usuario { get; set; }

    public virtual ICollection<DetallePedido> DetallesPedidos { get; set; }

    public virtual Efectivo Efectivo { get; set; }

    public virtual MercadoPago MercadoPago { get; set; }

    public Estado Estado { get; set; }
}
