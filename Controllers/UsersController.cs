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
    public class UsersController(IUserService userService, IOptions<AppSettings> appSettings, IHttpContextAccessor httpContextAccessor) : ControllerBase
    {
        private IUserService _userService = userService;
        private readonly AppSettings _appSettings = appSettings.Value;
        private IHttpContextAccessor _httpContextAccessor { get; } = httpContextAccessor;

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var userFromContextItem = _httpContextAccessor.HttpContext.Items["User"];
            var user = userFromContextItem ?? new User { UserName = "tam.ngo" };

            return Ok(user);
        }
    }


}
