using First.App.Tests.Entities;

namespace First.App.Tests.Contracts
{
    public interface IStockRepository
    {
        bool ChangeStock(Product product, int stock);
    }
}
