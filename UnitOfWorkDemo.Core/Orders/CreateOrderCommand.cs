using MediatR;

namespace UnitOfWorkDemo.Core.Orders
{
    public record CreateOrderCommand(int PersonId, int ProductId, int Count) : IRequest;
}
