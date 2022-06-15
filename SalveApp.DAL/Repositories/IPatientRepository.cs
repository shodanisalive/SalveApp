using SalveApp.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalveApp.DAL.Repositories
{
    public interface IPatientRepository : IRepository<Patient, int>
    {
    }
}
