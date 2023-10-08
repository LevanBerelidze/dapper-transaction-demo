using UnitOfWorkDemo.Core.Orders;
using UnitOfWorkDemo.Web.Models;

namespace UnitOfWorkDemo.Web.Mappers
{
    public static class OrderMapper
    {
        public static CreateOrderCommand ToCommand(this CreateOrderRequest request)
        {
            return new CreateOrderCommand(request.PersonId, request.PersonId, request.Count);
        }
    }
}
