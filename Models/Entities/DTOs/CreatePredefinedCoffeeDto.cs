namespace Models.Entities.DTOs;

public partial class CreatePredefinedCoffeeDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string Description { get; set; } = null!;
    
    public string Image { get; set; }
}