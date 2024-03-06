using Domain.Entities;

namespace buen_sabor.api.Entities
{
    public class Domicilio : BaseEntity
    {
        public string Calle { get; set; }
        
        public int Nro { get; set; }
        
        public string Localidad { get; set; }

        public Guid UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}
