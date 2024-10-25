using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreDB_DOMAIN1.Core.DTO;
using StoreDB_DOMAIN1.Core.Interfaces;

namespace StoreDB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] UserDTO userDTO)
        {
            if (userDTO.Email == "" || userDTO.Password == "") return BadRequest();
            //TODO: Mejorar el userService con DTO
            var result = await _userService.SignIn(userDTO.Email, userDTO.Password);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
