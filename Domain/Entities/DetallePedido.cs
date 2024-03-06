using Domain.Entities;

namespace buen_sabor.api.Entities;

public class DetallePedido : DetalleEntity
{
    public Guid ManufacturadoId { get; set; }

    public virtual Manufacturado Manufacturado { get; set; }

    public Guid PedidoId { get; set; }
    
    public virtual Pedido Pedido { get; set; }

    public virtual ICollection<Articulo> Articulos { get; set; }
}
