using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaStepTestProject.Entities;

public class Customer
{
    [Column(Order = 0)]
    public int Id { get; set; }

    [Column(Order = 1)]
    [StringLength(200)]
    public string FullName { get; set; } = string.Empty;

    [Column(Order = 2)]
    [StringLength(200)]
    public string Email { get; set; } = string.Empty;

    [Column(Order = 3)]
    public DateTime? Dob { get; set; }

    public IEnumerable<CustomerProduct> CustomerProducts { get; set; } = new List<CustomerProduct>();
}
