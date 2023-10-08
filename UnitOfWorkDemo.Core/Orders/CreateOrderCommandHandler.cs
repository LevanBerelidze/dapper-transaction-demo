using MediatR;
using UnitOfWorkDemo.Core.Persons;
using UnitOfWorkDemo.Core.Products;

namespace UnitOfWorkDemo.Core.Orders
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository orderRepository;
        private readonly IPersonRepository personRepository;
        private readonly IProductRepository productRepository;

        public CreateOrderCommandHandler(
            IOrderRepository orderRepository,
            IPersonRepository personRepository,
            IProductRepository productRepository)
        {
            this.orderRepository = orderRepository;
            this.personRepository = personRepository;
            this.productRepository = productRepository;
        }

        public Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            Product product = productRepository.GetById(request.ProductId);

            Order order = new Order
            {
                PersonId = request.PersonId,
                ProductId = request.ProductId,
                Count = request.Count,
                Price = product.Price,
                PriceCurrencyId = product.PriceCurrencyId,
                CreateDate = DateTimeOffset.Now,
            };
            orderRepository.Add(order);

            decimal totalCost = order.GetTotalCost();
            personRepository.UpdateBalance(request.PersonId, product.PriceCurrencyId, totalCost);

            productRepository.DecreaseStockAmount(product.Id, order.Count);

            return Task.CompletedTask;
        }
    }
}
