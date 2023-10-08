namespace UnitOfWorkDemo.Core.Persons
{
    public interface IPersonRepository
    {
        void UpdateBalance(int personId, int currencyId, decimal difference);
    }
}
