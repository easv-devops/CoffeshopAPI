using Models.Entities;

namespace Business.Service;

public interface IOrderService
{
    IList<Order> GetOrders();
    Order? GetOrder(Guid id);
    bool OrderExists(Guid id);
    Order UpdateOrder(Guid id, Order order);
    void DeleteOrder(Guid id);
    Order CreateOrder(Order order);
}