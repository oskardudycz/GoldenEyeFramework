using System.Linq;
using System.Threading.Tasks;
using GoldenEye.Backend.Core.Services;
using GoldenEye.Shared.Core.Objects.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GoldenEye.Frontend.Core.Web.Controllers
{
    public abstract class ReadonlyControllerBase<TService, TDto>: ControllerBase
        where TService : IReadonlyService<TDto> where TDto : class, IDTO
    {
        protected TService Service;

        protected ReadonlyControllerBase(TService service)
        {
            Service = service;
        }

        protected ReadonlyControllerBase()
        {
        }

        public virtual IQueryable<TDto> Get()
        {
            return Service.Query();
        }

        public virtual async Task<IActionResult> Get(int id)
        {
            var dto = await Service.GetAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }
    }
}
