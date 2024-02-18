namespace buen_sabor.api.Entities
{
    public class Domicilio
    {
        public Guid Id { get; set; }
        public string Calle { get; set; }
        public int Nro { get; set; }
        public string Localidad { get; set; }
    }
}
