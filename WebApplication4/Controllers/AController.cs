using DB.DbModels;
using DB;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("a")]
    public class AController : ControllerBase
    {
        private readonly IGenericRepository<User> _userRepository;

        public AController(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<User> GetByUsername(string username)
        {
            return (await _userRepository.GetAllAsync()).FirstOrDefault();
        }
    }
}
