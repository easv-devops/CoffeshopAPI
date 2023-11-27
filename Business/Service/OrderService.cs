using Data.Repository;
using Models.Entities;

namespace Business.Service;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    
    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    public IList<Order> GetOrders()
    {
        return _orderRepository.GetOrders();
    }
    
    public Order? GetOrder(Guid id)
    {
        return _orderRepository.GetOrder(id);
    }
    
    public bool OrderExists(Guid id)
    {
        return _orderRepository.OrderExists(id);
    }
    
    public Order UpdateOrder(Guid id, Order order)
    {
        return _orderRepository.UpdateOrder(id, order);
    }
    
    public void DeleteOrder(Guid id)
    {
        _orderRepository.DeleteOrder(id);
    }
    
    public Order CreateOrder(Order order)
    {
        return _orderRepository.CreateOrder(order);
    }
}