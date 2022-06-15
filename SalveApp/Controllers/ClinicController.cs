using Microsoft.AspNetCore.Mvc;
using SalveApp.BusinessLogic.Services;
using SalveApp.Infrastructure.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SalveApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class ClinicController : BaseController<Clinic, int>
    {
        public ClinicController(IClinicService service) : base(service)
        {
            this.service = service;
        }
    }
}
