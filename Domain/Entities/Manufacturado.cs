using Domain.Common;

namespace buen_sabor.api.Entities;

public class Manufacturado : BaseEntity
{
    public string Descripcion { get; set; }

    public DateTime TiempoPreparacion { get; set; }
    
    public Guid RubroId { get; set; }

    public virtual Rubro Rubro { get; set; }

    public virtual DetallePedido DetallePedido { get; set; }

    public virtual ICollection<DetalleManufacturado> DetallesManufacturado { get; set; }
}
