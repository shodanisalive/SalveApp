using SalveApp.DAL.Repositories;
using SalveApp.Infrastructure.Entities;

namespace SalveApp.BusinessLogic.Services.Impl
{
    public sealed class ClinicService : BaseService<Clinic, int>, IClinicService
    {
        public ClinicService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
