using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.Dtos;

public record ProductRequest
{
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(50, ErrorMessage = "Name too long")]
    public string Name { get; init; } = string.Empty;

    [Range(0.01, double.MaxValue, ErrorMessage = "Price cannot be negative")]
    public decimal Price { get; init; }
}