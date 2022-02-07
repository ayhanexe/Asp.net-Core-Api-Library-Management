using Authentication.Models.Dtos;
using Authentication.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<LoginResponseDto> Login([FromBody] LoginModelDto model)
        {
            return await _authService.Login(model);
        }
    }
}
