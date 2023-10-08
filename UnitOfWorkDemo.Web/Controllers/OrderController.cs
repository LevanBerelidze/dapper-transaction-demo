using MediatR;
using Microsoft.AspNetCore.Mvc;
using UnitOfWorkDemo.Core.Orders;
using UnitOfWorkDemo.Web.Mappers;
using UnitOfWorkDemo.Web.Models;

namespace UnitOfWorkDemo.Web.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public IActionResult CreateOrder(CreateOrderRequest request)
        {
            CreateOrderCommand command = request.ToCommand();
            mediator.Send(command);
            return Ok();
        }
    }
}
