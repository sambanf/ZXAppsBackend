using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using ZXAppsBackend.API.Controllers;
using ZXAppsBackend.Domain.Entities;
using ZXAppsBackend.Domain.Interfaces;
using System.Threading.Tasks;

namespace ZXAppsBackend.Tests.Controllers
{
    public class TmOperatorControllerResponseTests
    {
        [Fact]
        public async Task GetOperator_ReturnsExpectedOperator()
        {
            // Arrange: expected operator based on your JSON response
            var expectedOperator = new TmOperator
            {
                OperatorPk = 1,
                Nama = "NENG DIANI",
                // You can extend your entity with these extra fields if needed
                // NoOperator = "24A1",
                // Nip = "ZX23001",
                // StatusFk = 2
            };

            var mockRepo = new Mock<IOperatorRepository>();
            mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(expectedOperator);

            var controller = new TmOperatorController(mockRepo.Object);

            // Act
            var result = await controller.GetOperator(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var operatorObj = Assert.IsType<TmOperator>(okResult.Value);

            Assert.Equal(expectedOperator.OperatorPk, operatorObj.OperatorPk);
            Assert.Equal(expectedOperator.Nama, operatorObj.Nama);

            // If you extend TmOperator with additional properties:
            // Assert.Equal("24A1", operatorObj.NoOperator);
            // Assert.Equal("ZX23001", operatorObj.Nip);
            // Assert.Equal(2, operatorObj.StatusFk);
        }
    }
}
