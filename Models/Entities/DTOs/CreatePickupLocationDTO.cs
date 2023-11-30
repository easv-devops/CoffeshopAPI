namespace Models.Entities;

public partial class CreatePickupLocationDTO
{
    public Guid Id { get; set; }

    public string ShopName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int Phone { get; set; }
}