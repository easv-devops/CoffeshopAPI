namespace Models.Entities.DTOs;

public class UpdateOrderDto
{
    public DateTime PickupTime { get; set; }
    
    public bool IsPickedUp { get; set; }
}