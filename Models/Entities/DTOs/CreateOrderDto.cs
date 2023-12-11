namespace Models.Entities.DTOs;

public class CreateOrderDto
{
    public Guid UserId { get; set; }

    public Guid LocationId { get; set; }

    public decimal TotalPrice { get; set; }

    public DateTime OrderTime { get; set; }

    public DateTime PickupTime { get; set; }

    public bool IsCompleted { get; set; }
    
    public bool IsPickedUp { get; set; }
    
    public virtual ICollection<CreateOrderDetailDto> OrderDetails { get; set; } = new List<CreateOrderDetailDto>();
}