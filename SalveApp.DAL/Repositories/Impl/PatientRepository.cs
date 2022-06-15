using Microsoft.EntityFrameworkCore;
using SalveApp.Infrastructure.Entities;

namespace SalveApp.DAL.Repositories.Impl
{
    public sealed class PatientRepository : BaseRepository<Patient, int>, IPatientRepository
    {
        public PatientRepository(EFContext context) : base(context)
        {

        }
    }
}
