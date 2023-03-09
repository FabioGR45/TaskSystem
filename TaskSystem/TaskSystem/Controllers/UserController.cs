using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystem.Models;
using TaskSystem.Repositories;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> SearchAllUsers()
        {

            List<UserModel> users = await _userRepository.SearchAllUsers();
            return Ok(users);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> SearchById(int id)
        {
            UserModel user = await _userRepository.SearchById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> RegisterNewUser([FromBody] UserModel userModel)
        {
            UserModel user = await _userRepository.AddUser(userModel);
            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult<UserModel>> UpdateTask([FromBody] UserModel userModel, int id)
        {
            userModel.Id = id;
            UserModel user = await _userRepository.UpdateUser(userModel, id);
            return Ok($"User informations updated!");
        }

        [HttpDelete]
        public async Task<ActionResult<UserModel>> DeleteUser(int id)
        {
            await _userRepository.DeleteUser(id);

            return Ok("User successfully deleted!");
        }

    }
}
