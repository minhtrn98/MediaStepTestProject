using System.ComponentModel.DataAnnotations;

namespace MediaStepTestProject.Dtos;

public class CustomerDto
{
    public int Id { get; set; }

    [MaxLength(200)]
    public string FullName { get; set; } = string.Empty;

    [MaxLength(200)]
    // NOTE: add validatetion email
    public string Email { get; set; } = string.Empty;

    // NOTE: add validation dob cannot grater than now
    public DateTime? Dob { get; set; }
}
