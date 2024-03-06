using buen_sabor.api.Enums;
using Domain.Entities;

namespace buen_sabor.api.Entities;

public class Usuario : BaseEntity
{
    public string Nombre { get; set; }
    
    public string Apellido { get; set; }
    
    public string Telefono { get; set; }
    
    public string Email { get; set; }

    public ICollection<Domicilio> Domicilios { get; set; }

    public ICollection<Pedido> Pedido { get; set; }

    public Rol Rol { get; set; }
}
