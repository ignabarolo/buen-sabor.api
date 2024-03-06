using Domain.Entities;

namespace buen_sabor.api.Entities;

public class Rubro : BaseEntity 
{
    public string Nombre { get; set; }

    public virtual ICollection<Manufacturado> Manufacturados { get; set; }

    public virtual ICollection<Articulo> Articulos { get; set; }
}
