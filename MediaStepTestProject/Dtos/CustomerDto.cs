using System.ComponentModel.DataAnnotations;

namespace MediaStepTestProject.Dtos;

public class CustomerDto
{
    public int Id { get; set; }

    [MaxLength(200)]
    public string FullName { get; set; } = string.Empty;

    [MaxLength(200)]
    [ValidEmail]
    public string Email { get; set; } = string.Empty;

    // NOTE: add validation dob cannot grater than now
    [ValidDoB]
    public DateTime? Dob { get; set; }
}
