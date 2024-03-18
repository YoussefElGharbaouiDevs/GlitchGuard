using System.ComponentModel.DataAnnotations.Schema;
using GlitchGuard.Domain.Models.Common;

namespace GlitchGuard.Domain.Models;

public class BugEntity : BaseEntity
{
    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Severity { get; set; } = null!;

    public string Status { get; set; } = null!;

    [ForeignKey("Module")] public int ModuleId { get; set; }

    public ModuleEntity Module { get; set; } = new();

    [ForeignKey("ReportedByUser")] public string ReportedByUserId { get; set; }

    public UserEntity ReportedByUser { get; set; } = null!;

    [ForeignKey("AssignedToUser")] public string? AssignedToUserId { get; set; }

    public UserEntity AssignedToUser { get; set; } = new();

    public DateTime DateReported { get; set; }

    public DateTime? DateResolved { get; set; }

    public ICollection<CommentEntity> Comments { get; set; } = new List<CommentEntity>();

    public ICollection<AttachementEntity> Attachments { get; set; } = new List<AttachementEntity>();
}