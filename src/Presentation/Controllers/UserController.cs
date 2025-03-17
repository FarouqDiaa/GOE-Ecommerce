using Application.Abstractions.Services;
using Application.DTOs.LoginDTO;
using Application.DTOs.UserDTOs;
using Application.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.UserViewModels;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(
            IUserService userService,
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([Required][FromBody] SignUpViewModel signUpViewModel)
        {
            var user = _mapper.Map<SignUpDTO>(signUpViewModel);
            var token = await _userService.RegisterUserAsync(user);
            return Created(string.Empty, new SuccessResponse<string>(token));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel loginViewModel)
        {
            var userDTO = _mapper.Map<LoginDTO>(loginViewModel);
            var token = await _userService.LoginUserAsync(userDTO);
            
            return Ok(new SuccessResponse<string>(token));
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetUserDetails(Guid id)
        {
            var user = await _userService.GetUserDetailsAsync(id);

            var userViewModel = _mapper.Map<UserViewModel>(user);
            return Ok(new SuccessResponse<UserViewModel>(userViewModel));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
