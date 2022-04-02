using First.App.Tests.Entities;

namespace First.App.Tests.Contracts
{
    public interface IProductRepository
    {
        Product GetById(int productId);
    }
}
