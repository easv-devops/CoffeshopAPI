namespace Models.Entities.DTOs;

public partial class CreatePickupLocationDto
{
    public Guid Id { get; set; }

    public string ShopName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int Phone { get; set; }
}