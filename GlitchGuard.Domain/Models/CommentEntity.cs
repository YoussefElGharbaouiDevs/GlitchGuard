using System.ComponentModel.DataAnnotations.Schema;
using GlitchGuard.Domain.Models.Common;

namespace GlitchGuard.Domain.Models;

public class CommentEntity : BaseEntity
{
    public string Content { get; set; } = null!;

    [ForeignKey("AuthorUser")] public string AuthorUserId { get; set; }

    public UserEntity AuthorUser { get; set; } = new();

    [ForeignKey("Bug")] public int BugId { get; set; }

    public BugEntity Bug { get; set; } = new();
}