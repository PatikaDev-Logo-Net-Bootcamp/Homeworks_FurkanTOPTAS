using First.App.Tests.Contracts;
using First.App.Tests.Entities;

namespace First.App.Tests.Business
{
    public class ProductStockService
    {
        private readonly IProductRepository productRepository;
        private readonly IStockRepository stockRepository;
        private readonly ILogger logger;

        public ProductStockService(IProductRepository productRepository, IStockRepository stockRepository, ILogger logger)
        {
            this.productRepository = productRepository;
            this.stockRepository = stockRepository;
            this.logger = logger;
        }

        public bool ChangeStock(int productId, int stock)
        {
            Product product;
            try
            {
                product = productRepository.GetById(productId);
            }
            catch (System.Exception ex)
            {
                logger.Log(ex.ToString());
                return false;
            }

            if (product != null)
            {
                return stockRepository.ChangeStock(product, stock);
            }
            else
            {
                logger.Log("Stok bilgisi değiştirilemedi");
                return false;
            }
        }
    }
}
