using Domain.Common;

namespace buen_sabor.api.Entities;

public class DetalleManufacturado : DetalleEntity
{
    public Guid ArticuloId { get; set; }

    public virtual Articulo Articulo { get; set; }

    public Guid ManufacturadoId { get; set; }

    public virtual Manufacturado Manufacturado { get; set; }

}
