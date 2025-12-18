using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

/// <summary>
/// Represents the grade table.
/// </summary>
[Table("grade")]
public class GradeT
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(100)]
    public string LastName { get; set; }

    [Required]
    [StringLength(20)]
    public string Class { get; set; }

    [Required]
    [StringLength(300)]
    public string Subject { get; set; }

    [Required]
    [Range(1, 6)]
    public decimal Grade { get; set; }

    [StringLength(400)]
    public string Remark { get; set; }

    public DateTime CreationDate { get; set; }

    public Rounding Rounding { get; set; }
    public User Approver { get; set; }
    public Status Status { get; set; }
    public User Creator { get; set; }

    [ForeignKey(nameof(Rounding))]
    public int RoundingId { get; set; }

    [ForeignKey(nameof(Approver))]
    public int ApproverId { get; set; }

    [ForeignKey(nameof(Status))]
    public int StatusId { get; set; }

    [ForeignKey(nameof(Creator))]
    public int CreatorId { get; set; }
}
