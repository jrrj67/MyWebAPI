using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebAPI.Data.Requests;
using MyWebAPI.Data.Responses;
using MyWebAPI.Data.Services;
using System;
using System.Threading.Tasks;

namespace MyWebAPI.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IUsersService<UsersResponse, UsersRequest> _usersService;

        public LoginController(ILogger<LoginController> logger, IUsersService<UsersResponse, UsersRequest> usersService)
        {
            _logger = logger;
            _usersService = usersService;
        }

        [HttpPost]
        public IActionResult Authenticate(UsersRequest userRequest)
        {
            try
            {
                var response = _usersService.Login(userRequest);
                return Ok(response);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
