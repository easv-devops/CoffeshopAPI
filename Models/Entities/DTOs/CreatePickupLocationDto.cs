namespace Models.Entities.DTOs;

public class CreatePickupLocationDto
{
    public Guid Id { get; set; }

    public string ShopName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int Phone { get; set; }
}