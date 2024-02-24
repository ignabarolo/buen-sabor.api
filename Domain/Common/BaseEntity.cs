namespace Domain.Common;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    
    public DateTime Creado { get; set; }

    public DateTime Modificado { get; set; }
}
