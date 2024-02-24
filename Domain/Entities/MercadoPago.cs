using Domain.Common;

namespace buen_sabor.api.Entities;

public class MercadoPago : BaseEntity
{
    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public string CVU { get; set; }

    public string Alias { get; set; }

    public string CuilCuit { get; set; }

    public int Total { get; set; }

    public Guid PedidoId { get; set; }

    public virtual Pedido Pedido { get; set; }
}
