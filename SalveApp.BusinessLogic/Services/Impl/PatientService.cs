using SalveApp.DAL.Repositories;
using SalveApp.Infrastructure.Entities;

namespace SalveApp.BusinessLogic.Services.Impl
{
    public sealed class PatientService : BaseService<Patient, int>, IPatientService
    {
        public PatientService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
