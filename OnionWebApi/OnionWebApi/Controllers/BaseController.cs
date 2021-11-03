using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using OnionWebApi.Filters;
using OnionWebApi.Models.Entities;
using OnionWebApi.Services.Dtos;
using OnionWebApi.Services.Services;
using System.Threading.Tasks;

namespace OnionWebApi.Presentation.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BaseController<TEntity, TDto> : ControllerBase where TEntity : BaseEntity where TDto : BaseDto
    {
        private readonly IBaseService<TEntity, TDto> _baseService;
        public BaseController(IBaseService<TEntity, TDto> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public virtual IActionResult Get()
        {
            var dtos = _baseService.GetAll();
            return Ok(dtos);
        }

        [HttpGet("{id}")]

        public virtual  IActionResult GetById(int id)
        {
            var dtos = _baseService.GetById(id);
            return Ok(dtos);
        }

        [HttpGet("Query")]
        [EnableQuery]
        public virtual IActionResult Query()
        {
            var queryResult = _baseService.Query();
            return Ok(queryResult);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create([FromBody] TDto dto)
        {
            var dtoResult = await _baseService.Create(dto);
            return Ok(dtoResult);
        }

        [HttpPut]
        public virtual async Task<IActionResult> Update([FromBody] TDto dto)
        {
            var dtoResult = await _baseService.Update(dto);
            return Ok(dtoResult);
        }
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            await _baseService.Delete(id);
            return NoContent();
        }
    }
}
