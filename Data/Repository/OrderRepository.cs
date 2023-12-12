using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Data.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly CoffeeContext _context;

    public OrderRepository(CoffeeContext context)
    {
        _context = context;
    }

    public IList<Order> GetOrders()
    {
        return _context.Orders.Include(o => o.OrderDetails).ToList();
    }

    public Order GetOrder(Guid id)
    {
        return _context.Orders.Include(o => o.OrderDetails).FirstOrDefault(o => o.Id == id);
    }

    public bool OrderExists(Guid id)
    {
        return _context.Orders.Any(e => e.Id == id);
    }

    public Order UpdateOrder(Guid id, Order order)
    {
        var orderToUpdate = GetOrder(id);
        orderToUpdate.IsPickedUp = order.IsPickedUp;
        orderToUpdate.PickupTime = DateTime.Now;
        _context.SaveChanges();
        return order;
    }

    public void DeleteOrder(Guid id)
    {
        var order = _context.Orders.Find(id);
        _context.Orders.Remove(order);
        _context.SaveChanges();
    }

    public Order CreateOrder(Order order)
    {
        order.OrderTime = DateTime.Now;
        order.IsCompleted = true;
        order.Id = Guid.NewGuid();
        foreach (var orderDetail in order.OrderDetails)
        {
            orderDetail.OrderId = order.Id;
            order.TotalPrice += orderDetail.Price;
            _context.OrderDetails.Add(orderDetail);
        }
        _context.Orders.Add(order);
        _context.SaveChanges();
        return order;
    }
}