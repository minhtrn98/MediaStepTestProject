using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaStepTestProject.Entities;

public class Shop
{
    [Column(Order = 0)]
    public int Id { get; set; }

    [Column(Order = 1)]
    [StringLength(200)]
    public string Name { get; set; } = string.Empty;

    [Column(Order = 2)]
    public string? Location { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}
