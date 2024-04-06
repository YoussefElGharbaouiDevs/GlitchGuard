using System.ComponentModel.DataAnnotations;

namespace GlitchGuard.Domain.Models.Common;

public class BaseEntity
{
    [Key] public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime ModifiedAt { get; set; } = DateTime.Now;

    public string CreatedBy { get; set; } = null!;

    public string ModifiedBy { get; set; } = null!;
}