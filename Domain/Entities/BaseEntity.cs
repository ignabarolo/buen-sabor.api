namespace Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; }

    public bool Habilitado { get; set; }

    public DateTime Creado { get; set; }

    public DateTime Modificado { get; set; }
}
