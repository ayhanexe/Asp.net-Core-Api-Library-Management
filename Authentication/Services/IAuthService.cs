using Authentication.Models.Dtos;
using System.Threading.Tasks;

namespace Authentication.Services
{
    public interface IAuthService
    {
        public Task<LoginResponseDto> Login(LoginModelDto model);
    }
}
