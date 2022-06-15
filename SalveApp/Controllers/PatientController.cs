using Microsoft.AspNetCore.Mvc;
using SalveApp.BusinessLogic.Services;
using SalveApp.Infrastructure.Entities;
using SalveApp.Infrastructure.Requests;
using SalveApp.Infrastructure.Utils;
using System.Threading;
using System.Threading.Tasks;

namespace SalveApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class PatientController : BaseController<Patient, int>
    {
        public PatientController(IPatientService service) : base(service)
        {
            this.service = service;
        }

        [HttpGet("listByClinic/{clinicId}")]
        public async Task<IActionResult> ListByClinicAsync(int clinicId, [FromQuery] ListRequest listRequest, CancellationToken cancellationToken = default)
        {
            return new JsonResult(
                await service.ListAsync(x => x.ClinicId == clinicId,
                    new SortingOptions(listRequest.SortingColumn, listRequest.SortAscending),
                    new PagingOptions(listRequest.PageIndex, listRequest.PageSize)
                )
            );
        }
    }
}
