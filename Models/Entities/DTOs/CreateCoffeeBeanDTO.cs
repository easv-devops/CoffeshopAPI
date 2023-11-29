namespace Models.Entities;

public partial class CreateCoffeeBeanDTO
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string Description { get; set; } = null!;
}