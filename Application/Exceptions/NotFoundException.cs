
using buen_sabor.api.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Xml.Linq;

namespace Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) { }

    public NotFoundException(string message, Exception inner) : base(message, inner) { }
    public NotFoundException(string objectName, object key) 
        : base($"Entidad: \"{objectName}\" ID:({key}) no fue encontrada.") { }
}
