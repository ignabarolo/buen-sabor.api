using Domain.Common;

namespace buen_sabor.api.Entities;

public class Efectivo : BaseEntity
{
    public int Total { get; set; }

    public Guid PedidoId { get; set; }

    public virtual Pedido Pedido { get; set; }
}
