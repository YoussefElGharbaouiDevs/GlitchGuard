using System.ComponentModel.DataAnnotations.Schema;
using GlitchGuard.Domain.Models.Common;

namespace GlitchGuard.Domain.Models;

public class ModuleEntity : BaseEntity
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Version { get; set; } = null!;

    [ForeignKey("Application")] public int ApplicationId { get; set; }

    public ApplicationEntity Application { get; set; } = new();

    public ICollection<BugEntity> Bugs { get; set; } = new List<BugEntity>();
}