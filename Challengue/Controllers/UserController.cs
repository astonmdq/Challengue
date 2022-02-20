using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Challengue.Repository;
using Challengue.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Challengue.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;



        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        [HttpGet("MyRestfulapp/User")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("MyRestfulapp/User/{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var _user = await _userRepository.GetUserByIdAsync(id);
            if (_user == null)
                return NotFound();
            return Ok(_user);
        }

        [HttpPost("MyRestfulapp/User")]
        public async Task<IActionResult> AddNewUser([FromBody] UserModel user)
        {
            var _id = await _userRepository.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUserById),new { id = _id, controller = "user"},_id);
        
        }

        [HttpPut("MyRestfulapp/User/{id}")]
        public async Task<IActionResult> UpdateUser([FromBody] UserModel user,[FromRoute]int id)
        {
            await _userRepository.UpdateUserAsync(id, user);
            return Ok();
        }

        [HttpDelete("MyRestfulapp/User/{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute]int Id)
        {
            await _userRepository.DeleteUserAsync(Id);
            return Ok();
        }
    }
}
