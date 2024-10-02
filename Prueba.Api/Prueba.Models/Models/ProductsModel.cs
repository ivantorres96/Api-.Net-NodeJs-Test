using System.ComponentModel.DataAnnotations;

namespace Prueba.Models.Models;

public class ProductsModel
{
    [Key]
    public int Id { get; set; }
    
    [Required, MaxLength(100)]
    public string? Name { get; set; }
    
    [Required, MaxLength(255)]
    public string? Description { get; set; }
    
    public decimal Price { get; set; }
    
    public int Stock { get; set; }
}