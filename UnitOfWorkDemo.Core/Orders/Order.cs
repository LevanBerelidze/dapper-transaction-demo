namespace UnitOfWorkDemo.Core.Orders
{
    public class Order
    {
        public int Id { get; init; }
        public required int PersonId { get; init; }
        public required int ProductId { get; init; }
        public required int Count { get; init; }
        public required decimal Price { get; init; }
        public required decimal PriceCurrencyId { get; init; }
        public required DateTimeOffset CreateDate { get; init; }

        public decimal GetTotalCost()
        {
            return Price * Count;
        }
    }
}
