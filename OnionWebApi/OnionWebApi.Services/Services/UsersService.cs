using AutoMapper;
using OnionWebApi.BL.Dtos;
using OnionWebApi.Models.Contexts;
using OnionWebApi.Models.Entities;

namespace OnionWebApi.Services.Services
{
    public interface IUsersService : IBaseService<User, UsersDto>
    {
    }
    public class UsersService : BaseServices<User, UsersDto>, IUsersService
    {
        public UsersService(BaseContext baseContext, IMapper mapper) : base(baseContext, mapper)
        {
        }
    }
}
