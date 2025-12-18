using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

/// <summary>
/// Represents the user table.
/// </summary>
[Table("user")]
public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(100)]
    public string Email { get; set; }

    [Required]
    [StringLength(50)]
    public string Password { get; set; }

    [Required]
    [StringLength(100)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(100)]
    public string LastName { get; set; }

    public Role Role { get; set; }

    [ForeignKey(nameof(Role))]
    public int RoleId { get; set; }

    public ICollection<GradeT> CreatedGrades { get; set; }
    public ICollection<GradeT> ApprovedGrades { get; set; }
}
