using Microsoft.AspNetCore.Mvc;
using SalveApp.BusinessLogic.Services;
using SalveApp.Infrastructure;
using SalveApp.Infrastructure.Requests;
using SalveApp.Infrastructure.Utils;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SalveApp.Controllers
{
    public class BaseController<TEntity, TKey> : ControllerBase
        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        protected IService<TEntity, TKey> service;

        public BaseController(IService<TEntity, TKey> service)
        {
            this.service = service;
        }

        [HttpGet("list")]
        public virtual async Task<IActionResult> ListAsync([FromQuery] ListRequest listRequest, CancellationToken cancellationToken = default)
        {
            return new JsonResult(
                await service.ListAsync(null,
                    new SortingOptions(listRequest.SortingColumn, listRequest.SortAscending),
                    new PagingOptions(listRequest.PageIndex, listRequest.PageSize)
                )
            );
        }
    }
}
