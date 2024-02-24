using Domain.Common;

namespace buen_sabor.api.Entities;

public class Articulo : BaseEntity
{
    public string Descripcion { get; set; }

    public string UnidadMedida { get; set; }

    public int Stock { get; set; }

    public Guid DetallePedidoId { get; set; }

    public virtual DetallePedido DetallePedido { get; set; }

    public Guid RubroId { get; set; }

    public virtual Rubro Rubro { get; set; }

    public virtual ICollection<CompraArticulo> CompraArticulo { get; set; }
}
