using First.App.Tests.Business;
using First.App.Tests.Contracts;
using First.App.Tests.Entities;
using NSubstitute;
using NUnit.Framework.Internal;
using Xunit;
using Xunit.Sdk;
using ILogger = First.App.Tests.Contracts.ILogger;


namespace First.App.Tests
{
    public class ProductStockServiceTests
    {
        private IProductRepository productRepository;
        private IStockRepository stockRepository;
        private ILogger logger;
        private ProductStockService productStockService;

        
        public ProductStockServiceTests()
        {
            productRepository = Substitute.For<IProductRepository>();
            stockRepository = Substitute.For<IStockRepository>();
            logger = Substitute.For<ILogger>();
            productStockService = new ProductStockService(productRepository, stockRepository, logger);
        }
       

        [Fact]
        public void ChangeStock_WhenProductNotNull_Change()
        {
            //Arrange
            productRepository.GetById(Arg.Is<int>(a => a < 10))
                .Returns(new Product { Name = "Cep Telefonu", Stock = 100 });

            stockRepository.ChangeStock(Arg.Any<Product>(), Arg.Any<int>())
                .Returns(true);

            //Act
            var result = productStockService.ChangeStock(5, 50);

            //Assert
            Assert.True(result);
               
        }

        [Fact]
        public void ChangeStock_WhenProductNull_WriteLogMsg()
        {
            //Act
            productStockService.ChangeStock(5, 50);

            //assert
            logger.Received().Log(Arg.Any<string>());
        }
    }
}
