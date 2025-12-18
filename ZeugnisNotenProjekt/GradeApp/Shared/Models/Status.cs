using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

/// <summary>
/// Represents the status table.
/// </summary>
[Table("status")]
public class Status
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(20)]
    public string Name { get; set; }

    public ICollection<GradeT> Grades { get; set; }
}
