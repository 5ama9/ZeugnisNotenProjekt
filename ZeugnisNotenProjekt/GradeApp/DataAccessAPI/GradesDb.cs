using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace DataAccessAPI;

public class GradesDb : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GradesDb"/> class.
    /// </summary>
    /// <param name="options">The options to be used by the DbContext.</param>
    public GradesDb(DbContextOptions<GradesDb> options) :
        base(options)
    { }

    /// <summary>
    /// Gets the collection of Grade in the database.
    /// </summary>
    public DbSet<GradeT> Grades { get; set; }

    /// <summary>
    /// Gets the collection of User in the database.
    /// </summary>
    public DbSet<User> Users { get; set; }

    /// <summary>
    /// Gets the collection of Role in the database.
    /// </summary>
    public DbSet<Role> Roles { get; set; }

    /// <summary>
    /// Gets the collection of Rounding in the database.
    /// </summary>
    public DbSet<Rounding> Roundings { get; set; }

    /// <summary>
    /// Gets the collection of Status in the database.
    /// </summary>
    public DbSet<Status> Statuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<GradeT>()
        .HasOne(g => g.Creator)            // Grade hat EINEN Creator
        .WithMany(u => u.CreatedGrades)    // User hat VIELE erstellte Grades
        .HasForeignKey(g => g.CreatorId)   // FK in Grade
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<GradeT>()
        .HasOne(g => g.Approver)
        .WithMany(u => u.ApprovedGrades)
        .HasForeignKey(g => g.ApproverId)
        .OnDelete(DeleteBehavior.Restrict);
    }
}
