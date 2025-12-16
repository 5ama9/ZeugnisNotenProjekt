using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models.DTOs;

public class CreateGradeDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Class { get; set; }
    public string Subject { get; set; }
    public decimal Grade { get; set; }
    public string Remark { get; set; }
    public int RoundingId { get; set; }
    public int ApproverId { get; set; }
}
