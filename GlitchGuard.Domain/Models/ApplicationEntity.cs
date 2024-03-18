using GlitchGuard.Domain.Models.Common;

namespace GlitchGuard.Domain.Models;

public class ApplicationEntity : BaseEntity
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Version { get; set; } = null!;

    public DateTime ReleaseDate { get; set; }

    public ICollection<ModuleEntity> Modules { get; set; } = new List<ModuleEntity>();
}