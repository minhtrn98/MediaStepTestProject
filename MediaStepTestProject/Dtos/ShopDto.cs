using System.ComponentModel.DataAnnotations;

namespace MediaStepTestProject.Dtos;

public class ShopDto
{
    public int Id { get; set; }

    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;
    public string? Location { get; set; }
}
