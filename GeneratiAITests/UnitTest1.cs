using GenerativeAITest.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using Stripe;

namespace GeneratiAITests
{
    [TestFixture]
    public class TransactionControllerTests
    {
        private TransactionController _transactionController;
        private Mock<IConfiguration> _configurationMock;
        private Mock<BalanceService> _balanceServiceMock;
        private Mock<BalanceTransactionService> _balanceTransactionServiceMock;

        [SetUp]
        public void Setup()
        {
            _configurationMock = new Mock<IConfiguration>();
            _balanceServiceMock = new Mock<BalanceService>();
            _balanceTransactionServiceMock = new Mock<BalanceTransactionService>();
            _transactionController = new TransactionController(_configurationMock.Object, 
                _balanceServiceMock.Object,
                _balanceTransactionServiceMock.Object);
        }

        [Test]
        public void GetListBalance_ReturnsOkResult()
        {
            // Arrange
            _configurationMock.Setup(c => c["StripeApiKeyWrite"]).Returns("your_stripe_api_key");
            _balanceServiceMock.Setup(b => b.Get(null)).Returns(new Balance());

            // Act
            var result = _transactionController.GetListBalance() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public void GetListBalance_ReturnsBadRequestResult_WhenExceptionThrown()
        {
            // Arrange
            _configurationMock.Setup(c => c["StripeApiKeyWrite"]).Returns("your_stripe_api_key");
            _balanceServiceMock.Setup(b => b.Get(null)).Throws(new Exception("Test exception"));


            // Act
            var result = _transactionController.GetListBalance() as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual("Test exception", result.Value);
        }

        [Test]
        public void GetPaginatedListBalance_ReturnsOkResult()
        {
            // Arrange
            long? limit = 10;
            string startingAfter = "some_starting_after_value";
            _configurationMock.Setup(c => c["StripeApiKeyWrite"]).Returns("your_stripe_api_key");
            _balanceTransactionServiceMock.Setup(b => b.List(It.IsAny<BalanceTransactionListOptions>(), It.IsAny<RequestOptions>()))
                .Returns(new StripeList<BalanceTransaction>());

            // Act
            var result = _transactionController.GetPaginatedListBalance(limit, startingAfter) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public void GetPaginatedListBalance_ReturnsBadRequestResult_WhenExceptionThrown()
        {
            // Arrange
            long? limit = 10;
            string startingAfter = "some_starting_after_value";
            _configurationMock.Setup(c => c["StripeApiKeyWrite"]).Returns("your_stripe_api_key");
            _balanceTransactionServiceMock.Setup(b => b.List(It.IsAny<BalanceTransactionListOptions>(), It.IsAny<RequestOptions>()))
                .Throws(new Exception("Test exception"));
            // Act
            var result = _transactionController.GetPaginatedListBalance(limit, startingAfter) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual("Test exception", result.Value);
        }
    }
}