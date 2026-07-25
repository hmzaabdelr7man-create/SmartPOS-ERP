namespace SmartPOS.Application.Mapping;

using AutoMapper;

/// <summary>
/// Base class for AutoMapper profiles that map between domain entities and application contracts.
/// </summary>
public abstract class MappingProfileBase : Profile
{
    /// <summary>Initializes a new instance of the <see cref="MappingProfileBase" /> class.</summary>
    protected MappingProfileBase()
    {
    }
}
