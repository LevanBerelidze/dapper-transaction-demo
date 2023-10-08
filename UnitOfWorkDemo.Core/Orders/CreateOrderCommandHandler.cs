using MediatR;
using UnitOfWorkDemo.Core.Common;
using UnitOfWorkDemo.Core.Persons;
using UnitOfWorkDemo.Core.Products;

namespace UnitOfWorkDemo.Core.Orders
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly ITransactionManager transactionManager;
        private readonly IOrderRepository orderRepository;
        private readonly IPersonRepository personRepository;
        private readonly IProductRepository productRepository;

        public CreateOrderCommandHandler(
            ITransactionManager transactionManager,
            IOrderRepository orderRepository,
            IPersonRepository personRepository,
            IProductRepository productRepository)
        {
            this.transactionManager = transactionManager;
            this.orderRepository = orderRepository;
            this.personRepository = personRepository;
            this.productRepository = productRepository;
        }

        public Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            transactionManager.Begin();

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

            transactionManager.Commit();

            return Task.CompletedTask;
        }
    }
}
