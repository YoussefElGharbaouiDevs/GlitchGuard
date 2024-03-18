using System.ComponentModel.DataAnnotations.Schema;
using GlitchGuard.Domain.Models.Common;

namespace GlitchGuard.Domain.Models;

public class AttachementEntity : BaseEntity
{
    public string FileName { get; set; } = null!;

    public string FileType { get; set; } = null!;

    public long FileSize { get; set; }

    [ForeignKey("Bug")] public int BugId { get; set; }

    public BugEntity Bug { get; set; } = new();

    [ForeignKey("AuthorUser")] public string? AuthorUserId { get; set; }

    public UserEntity AuthorUser { get; set; } = new();
}