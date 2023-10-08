namespace UnitOfWorkDemo.Core.Products
{
    public class Product
    {
        public int Id { get; init; }
        public required string Title { get; init; }
        public required decimal Price { get; init; }
        public required int PriceCurrencyId { get; init; }
        public required int LeftInStock { get; init; }
    }
}
