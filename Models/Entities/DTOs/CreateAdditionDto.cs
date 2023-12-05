namespace Models.Entities.DTOs;

public partial class CreateAdditionDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int Amount { get; set; }
}