using buen_sabor.api.Enums;
using Domain.Common;

namespace buen_sabor.api.Entities;

public class Pedido : BaseEntity
{
    public DateTime HoraEstimada { get; set; }

    public bool Retirolocal { get; set; }
    
    public int Descuento { get; set; }
    
    public Guid ClienteId { get; set; }

    public virtual Usuario Cliente { get; set; }

    public virtual ICollection<DetallePedido> DetallesPedido { get; set; }

    public Estado Estado { get; set; }
}
