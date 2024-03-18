using GlitchGuard.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GlitchGuard.Infrastructure.Data;

public class GlitchGuardDbContext : IdentityDbContext<UserEntity, UserRoleEntity, string, IdentityUserClaim<string>,
    IdentityUserRole<string>, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
{
    public GlitchGuardDbContext(DbContextOptions options) : base(options)
    {
    }

    #region DbSets

    public DbSet<ApplicationEntity> Applications { get; set; }
    public DbSet<ModuleEntity> Modules { get; set; }
    public DbSet<AttachementEntity> Attachements { get; set; }
    public DbSet<BugEntity> Bugs { get; set; }
    public DbSet<CommentEntity> Comments { get; set; }
    public DbSet<UserEntity> Users { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region CustomTableNames

        modelBuilder.Entity<UserEntity>().ToTable("Users");
        modelBuilder.Entity<UserRoleEntity>().ToTable("Roles");
        modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
        modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
        modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
        modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
        modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");

        #endregion
        
        modelBuilder.Entity<BugEntity>()
            .HasOne(b => b.ReportedByUser)
            .WithMany()
            .HasForeignKey(b => b.ReportedByUserId)
            .OnDelete(DeleteBehavior.NoAction); 
        
        
        modelBuilder.Entity<AttachementEntity>()
            .HasOne(a => a.AuthorUser)
            .WithMany()
            .HasForeignKey(a => a.AuthorUserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CommentEntity>()
            .HasOne(c => c.AuthorUser)
            .WithMany()
            .HasForeignKey(c => c.AuthorUserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}