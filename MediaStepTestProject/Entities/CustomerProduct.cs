using System.ComponentModel.DataAnnotations;

namespace MediaStepTestProject.Entities;

public class CustomerProduct
{
    [Key]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    [Key]
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public int Quantity { get; set; }
}
