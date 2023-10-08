namespace UnitOfWorkDemo.Core.Products
{
    public interface IProductRepository
    {
        Product GetById(int id);
        void DecreaseStockAmount(int productId, int difference);
    }
}
