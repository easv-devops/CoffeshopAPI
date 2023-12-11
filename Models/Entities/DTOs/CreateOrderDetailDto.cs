namespace Models.Entities.DTOs;

public class CreateOrderDetailDto
{
    public Guid Id { get; set; }

    public Guid? PredefinedCoffeeId { get; set; }

    public Guid? CustomCoffeeId { get; set; }

    public Guid? CookieId { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }
}