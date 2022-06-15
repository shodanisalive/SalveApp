using Microsoft.EntityFrameworkCore;
using SalveApp.Infrastructure.Entities;

namespace SalveApp.DAL.Repositories.Impl
{
    public sealed class ClinicRepository : BaseRepository<Clinic, int>, IClinicRepository
    {
        public ClinicRepository(EFContext context) : base(context)
        {

        }
    }
}
