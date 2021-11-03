using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnionWebApi.Models.Contexts;
using OnionWebApi.Models.Entities;
using OnionWebApi.Services.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnionWebApi.Services.Services
{ 
    public interface IBaseService<TEntity, TDto> where TEntity : BaseEntity where TDto : BaseDto
    {
        IQueryable<TEntity> Query();
        ICollection<TDto> GetAll();
        TDto GetById(int id);
        Task<TDto> Create(TDto dto);
        Task<TDto> Update(TDto dto);
        Task Delete(int id);
    }
    public class BaseServices<TEntity, TDto> : IBaseService<TEntity, TDto> where TEntity : BaseEntity where TDto : BaseDto 
    {
        protected readonly BaseContext _context;

        protected readonly DbSet<TEntity> _dbSet;

        protected readonly IMapper _mapper;

        public BaseServices(BaseContext context, IMapper mapper)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
            _mapper = mapper;
        }
        public IQueryable<TEntity> Query()
        {
            return _dbSet.AsQueryable();
        }

        public virtual ICollection<TDto> GetAll()
        {
            var entities = Query();

            var dtos = _mapper.Map<ICollection<TDto>>(entities);

            return dtos;
        }

        public virtual TDto GetById(int id)
        {
            var entity = Query().Where(x => x.Id == id).FirstOrDefault();

            return _mapper.Map<TDto>(entity);
        }
        
        public virtual async Task<TDto> Create(TDto dto)
        {

            var entity = _mapper.Map<TEntity>(dto);

            _dbSet.Add(entity);

            await _context.SaveChangesAsync();

            return _mapper.Map(entity, dto);
        }
        public virtual async Task<TDto> Update(TDto dto)
        {
            var entityExist = Query().Any(x => x.Id == dto.Id);
            if (entityExist is false) return null;

            var entity = _mapper.Map<TEntity>(dto);

            _dbSet.Update(entity);

            await _context.SaveChangesAsync();
            
            return _mapper.Map(entity, dto);
        }

        public virtual async Task Delete(int id)
        {
            var entity = await Query().Where(x => x.Id == id).FirstOrDefaultAsync();

            if (entity is null) return;

            _dbSet.Remove(entity);

            await _context.SaveChangesAsync();
        }
    }
}
