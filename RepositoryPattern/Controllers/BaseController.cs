using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity, TEntityDto, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TEntityDto : class
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository _repository;
        private readonly IMapper _mapper;

        public BaseController(TRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            return await _repository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var entity = await _repository.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TEntityDto entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }

            try
            {
                await _repository.Add(_mapper.Map<TEntity>(entity));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TEntity entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }

            await _repository.Update(entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _repository.Delete(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }
    }
}
