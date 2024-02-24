using Domain.Common;

namespace buen_sabor.api.Entities
{
    public class CompraArticulo : DetalleEntity 
    {
        public double Precio { get; set; }

        public Guid ArticuloId { get; set; }

        public virtual Articulo Articulo { get; set; }
    }
}
