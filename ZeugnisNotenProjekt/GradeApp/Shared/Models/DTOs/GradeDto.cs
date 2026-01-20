using System.ComponentModel.DataAnnotations;

namespace Shared.Models.DTOs;
public class GradeDto
{
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;

    [Required]
    public string Class { get; set; } = string.Empty;

    [Required]
    public string Subject { get; set; } = string.Empty;

    [Range(1, 6, ErrorMessage = "Grade must be between 1 and 6")]
    public decimal Grade { get; set; }

    public string? Remark { get; set; }

    public DateTime CreationDate { get; set; }

    [Required(ErrorMessage = "Rounding is required")]
    public int? RoundingId { get; set; }

    public int StatusId { get; set; }

    public string CreatorName { get; set; }
    public string ApproverName { get; set; } = string.Empty;
}
