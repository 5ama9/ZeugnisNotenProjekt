namespace Shared.Models.DTOs;

public class GradeDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Class { get; set; }
    public string Subject { get; set; }

    public decimal Grade { get; set; }
    public string Remark { get; set; }
    public DateTime CreationDate { get; set; }

    public string Rounding { get; set; }
    public string Status { get; set; }

    public string CreatorName { get; set; }
    public string ApproverName { get; set; }
}
