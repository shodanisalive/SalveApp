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
    public class PatientServiceTests
    {
        private UnitOfWork _unitOfWork;

        public PatientServiceTests()
        {
            var dbName = $"PatientService_{DateTime.Now.ToFileTimeUtc()}";
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
            var service = new PatientService(_unitOfWork);

            // Act
            var list = await service.ListAsync();

            // Assert
            Assert.AreEqual<int>(list.Count, 2);
        }

        [TestMethod]
        public async Task ListClinicsFilterAsync_Success()
        {
            // Prepare
            await PopulateAsync();
            var service = new PatientService(_unitOfWork);

            // Act
            var list = await service.ListAsync(x => x.ClinicId == 1);

            // Assert
            Assert.AreEqual<int>(list.Count, 2);
        }

        [TestMethod]
        public async Task ListClinicsFilterAsync2_Success()
        {
            // Prepare
            await PopulateAsync();
            var service = new PatientService(_unitOfWork);

            // Act
            var list = await service.ListAsync(x => x.ClinicId == 1 && x.FirstName == "Marco");

            // Assert
            Assert.AreEqual<int>(list.Count, 1);
        }

        private async Task PopulateAsync()
        {
            var clinicRepository = _unitOfWork.GetRepository<Clinic, int>();
            clinicRepository.Add(new Clinic(1, "Clinic London"));

            var patientRepository = _unitOfWork.GetRepository<Patient, int>();
            patientRepository.Add(new Patient(1, "Marco", "Evangelisti", new DateTime(1982, 10, 21)));
            patientRepository.Add(new Patient(1, "John", "Doe", new DateTime(1982, 11, 20)));

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
