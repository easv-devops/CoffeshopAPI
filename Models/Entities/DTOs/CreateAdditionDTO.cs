namespace Models.Entities;

public partial class CreateAdditionDTO
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int Amount { get; set; }
}