using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ValidateJWT.Authorization;
using ValidateJWT.Entities;
using ValidateJWT.Helpers;
using ValidateJWT.Services;

namespace ValidateJWT.Controllers
{
    [CustomAuthorization]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private readonly AppSettings _appSettings;
        private IHttpContextAccessor _httpContextAccessor { get; }

        public UsersController(IUserService userService, IOptions<AppSettings> appSettings, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _appSettings = appSettings.Value;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var userFromContextItem = _httpContextAccessor.HttpContext.Items["User"];
            var user = userFromContextItem ?? new User { UserName = "tam.ngo" };

            return Ok(user);
        }
    }


}
