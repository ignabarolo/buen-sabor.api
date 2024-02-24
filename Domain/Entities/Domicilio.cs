using Domain.Common;

namespace buen_sabor.api.Entities
{
    public class Domicilio : BaseEntity
    {
        public string Calle { get; set; }
        public int Nro { get; set; }
        public string Localidad { get; set; }
    }
}
