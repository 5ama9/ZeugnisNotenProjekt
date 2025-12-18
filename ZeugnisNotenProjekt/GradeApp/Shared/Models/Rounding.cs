using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Shared.Models;
/// <summary>
/// Represents the rounding table.
/// </summary>
[Table("rounding")]
public class Rounding
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(10)]
    public string Name { get; set; }

    public ICollection<GradeT> Grades { get; set; }
}
