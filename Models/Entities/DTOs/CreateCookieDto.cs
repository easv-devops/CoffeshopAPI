namespace Models.Entities.DTOs;

public partial class CreateCookieDto
{
    public Guid Id { get; set; }

    public Guid? PredefinedCoffeeId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string Description { get; set; } = null!;
}