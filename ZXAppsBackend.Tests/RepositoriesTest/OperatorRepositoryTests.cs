using Microsoft.EntityFrameworkCore;
using Xunit;
using ZXAppsBackend.Domain.Entities;
using ZXAppsBackend.Infrastructure.Repositories;
using System.Threading.Tasks;
using System.Linq;
using ZXAppsBackend.Infrastructure;

namespace ZXAppsBackend.Tests.Repositories
{
    public class OperatorRepositoryExtendedTests
    {
        private AppDbContext GetInMemoryDbContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsOperatorWithAllFields()
        {
            var context = GetInMemoryDbContext("OperatorDb1");
            var operatorEntity = new TmOperator
            {
                OperatorPk = 1,
                NoOperator = "24A1",
                NIP = "ZX23001",
                Nama = "NENG DIANI",
                StatusFk = 2
            };
            context.Operators.Add(operatorEntity);
            await context.SaveChangesAsync();

            var repo = new OperatorRepository(context);

            var result = await repo.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("24A1", result.NoOperator);
            Assert.Equal("ZX23001", result.NIP);
            Assert.Equal("NENG DIANI", result.Nama);
            Assert.Equal(2, result.StatusFk);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsMultipleOperators()
        {
            var context = GetInMemoryDbContext("OperatorDb2");
            context.Operators.AddRange(
                new TmOperator { OperatorPk = 1, Nama = "Alice", NoOperator = "11A", NIP = "ZX1001", StatusFk = 1 },
                new TmOperator { OperatorPk = 2, Nama = "Bob", NoOperator = "22B", NIP = "ZX1002", StatusFk = 2 }
            );
            await context.SaveChangesAsync();

            var repo = new OperatorRepository(context);

            var result = await repo.GetAllAsync();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsNull_WhenOperatorNotExists()
        {
            var context = GetInMemoryDbContext("OperatorDb3");
            var repo = new OperatorRepository(context);

            var result = await repo.GetByIdAsync(999);

            Assert.Null(result);
        }
    }
}
