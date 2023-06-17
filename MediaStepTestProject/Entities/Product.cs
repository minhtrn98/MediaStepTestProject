using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaStepTestProject.Entities;

public class Product
{
    [Column(Order = 0)]
    public int Id { get; set; }

    [Column(Order = 1)]
    [StringLength(1000)]
    public string Name { get; set; } = string.Empty;

    [Column(Order = 2)]
    [Precision(18, 2)]
    public decimal Price { get; set; }

    [Column(Order = 3)]
    public int ShopId { get; set; }
    public Shop Shop { get; set; } = null!;

    public IEnumerable<CustomerProduct> CustomerProducts { get; set; } = new List<CustomerProduct>();
}