using System.ComponentModel.DataAnnotations;

namespace MediaStepTestProject.Dtos;

public class ProductDto
{
    public int Id { get; set; }

    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;
    // NOTE: validate max price, min price
    public decimal Price { get; set; }

    public int ShopId { get; set; }
}
