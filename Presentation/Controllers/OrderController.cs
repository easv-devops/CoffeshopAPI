using AutoMapper;
using Business.Service;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Entities.DTOs;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : Controller
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;

    public OrderController(IOrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }

    [HttpGet]
    [Route ("GetOrders")]
    public ActionResult GetOrders()
    {
        var orders = _orderService.GetOrders();
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public ActionResult GetOrder(Guid id)
    {
        var order = _orderService.GetOrder(id);
        if (order == null)
        {
            return NotFound();
        }
        
        return Ok(order);
    }

    [HttpPut("{id}")]
    public ActionResult<GetOrderDto> UpdateOrder(Guid id, [FromBody] UpdateOrderDto orderDto)
    {
        if (!_orderService.OrderExists(id))
        {
            return NotFound();
        }

        var order = new Order();
        _mapper.Map(orderDto, order);
        var updatedUser = _orderService.UpdateOrder(id, order);
        return Ok(updatedUser);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteOrder(Guid id)
    {
        _orderService.DeleteOrder(id);
        return Ok();
    }

    [HttpPost]
    public ActionResult CreateOrder([FromBody] CreateOrderDto createOrderDto)
    {
        var order = new Order();
        _mapper.Map(createOrderDto, order);
        var createdOrder = _orderService.CreateOrder(order);
        return CreatedAtAction(nameof(GetOrder), new {id = createdOrder.Id}, createdOrder);
    }
}   