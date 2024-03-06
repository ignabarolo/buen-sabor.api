using AutoMapper;
using System.Reflection;

namespace Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
    }

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
            .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
            .ToList();

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);

#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            var methodInfo = type.GetMethod("Mapping") ?? type.GetInterface("IMapFrom`1").GetMethod("Mapping");
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
            _ = (methodInfo?.Invoke(instance, new object[] { this }));
        }
    }
}
