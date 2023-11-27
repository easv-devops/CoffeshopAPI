using Models.Entities;

namespace Data.Repository;

public interface IOrderRepository
{
    IList<Order> GetOrders();
    Order GetOrder(Guid id);
    bool OrderExists(Guid id);
    Order UpdateOrder(Guid id, Order order);
    void DeleteOrder(Guid id);
    Order CreateOrder(Order order);
}