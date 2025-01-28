using Common.Enums;
using DB;
using DB.DbModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly ILogger<UserController> _logger;

        public UserController(IGenericRepository<User> userRepository, ILogger<UserController> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route($"{nameof(GetUserByName)}")]
        public async Task<User> GetUserByName(string name)
        {
            return (await _userRepository.GetWhereAsync(x => x.Name == name)).FirstOrDefault();
        }

        [HttpGet]

        [Route($"{nameof(IsPasswordCorrect)}")]
        public async Task<bool> IsPasswordCorrect(string username, string password)
        {
            var user = (await _userRepository.GetWhereAsync(x => x.Username == username)).FirstOrDefault();

            if (user != null)
            {
                return user.Password == password;
            }

            return false;
        }

        [HttpPost]

        [Route($"{nameof(AddUser)}")]
        public void AddUser(string name, string email, string password, string surname, string username)
        {
            _logger.LogDebug("trying to add user");
            _userRepository.AddAsync(new User()
            {
                Name = name,
                Email = email,
                Id = Guid.NewGuid(),
                Password = password,
                Surname = surname,
                Type = UserType.Normal,
                Username = username
            });
        }

        [HttpDelete]
        [Route($"{nameof(DeleteUser)}")]
        public async Task DeleteUser(User user)
        {
            await _userRepository.RemoveAsync(user);
        }
    }
}
