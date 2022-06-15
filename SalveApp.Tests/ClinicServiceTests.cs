using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalveApp.BusinessLogic.Services.Impl;
using SalveApp.DAL;
using SalveApp.DAL.Repositories.Impl;
using SalveApp.Infrastructure.Entities;
using System;
using System.Threading.Tasks;

namespace SalveApp.Tests
{
    [TestClass]
    public class ClinicServiceTests
    {
        private UnitOfWork _unitOfWork;

        public ClinicServiceTests()
        {
            var dbName = $"ClinicService_{DateTime.Now.ToFileTimeUtc()}";
            var dbContextOptions = new DbContextOptionsBuilder<EFContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
            var dbContext = new EFContext(dbContextOptions);
            _unitOfWork = new UnitOfWork(dbContext);
        }

        [TestMethod]
        public async Task ListClinicsAsync_Success()
        {
            // Prepare
            await PopulateAsync();
            var service = new ClinicService(_unitOfWork);

            // Act
            var list = await service.ListAsync();

            // Assert
            Assert.AreEqual<int>(list.Count, 3);
        }

        [TestMethod]
        public async Task ListClinicsFilterAsync_Success()
        {
            // Prepare
            await PopulateAsync();
            var service = new ClinicService(_unitOfWork);

            // Act
            var list = await service.ListAsync(x => x.Name.Contains("Newcastle"));

            // Assert
            Assert.AreEqual<int>(list.Count, 1);
        }

        private async Task PopulateAsync()
        {
            var repository = _unitOfWork.GetRepository<Clinic, int>();
            repository.Add(new Clinic(1, "Clinic London"));
            repository.Add(new Clinic(2, "Clinic Newcastle"));
            repository.Add(new Clinic(3, "Clinic Brighton"));
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
