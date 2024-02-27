using Application.Interfaces;
using Domain.Entities;
using Infrastructure.JwtHandler;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;

        private readonly IConfiguration _configuration;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserRepo userRepo, IConfiguration configuration, ILogger<UserController> logger)
        {
            _configuration = configuration;
            _userRepo = userRepo;
            _logger = logger;

        }

        [HttpPost]
        public IActionResult Login(Login user)
        {
            try
            {
                var userAvaliable = _userRepo.Login(user);

                if (userAvaliable == null)
                {
                    return NotFound();
                }

                _logger.LogInformation($"{userAvaliable}");

                var jwtService = new JwtService(_configuration);
                var token = jwtService.GenerateToken(
                    userAvaliable.Id,
                    userAvaliable.Email,
                    userAvaliable.Role
                     );

                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }



        }

    }
}
