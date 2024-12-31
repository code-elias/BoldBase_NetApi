using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RepositoryNetAPI.Models;
using RepositoryNetAPI.Models.AppModels;
using RepositoryNetAPI.Repositories.Interfaces;

namespace RepositoryNetAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController(IRepository<User> userRepository) : ControllerBase
    {
        private readonly IRepository<User> _userRepository = userRepository;
        private readonly PasswordHasher<User> _passwordHasher = new();

        [HttpPost("register")]
        public IActionResult Register([FromBody] Account newAccount)
        {
            User newUser = newAccount.GetUserModel();
            newUser.PasswordHash = _passwordHasher.HashPassword(newUser, newUser.PasswordHash);

            _userRepository.Add(newUser);
            _userRepository.Save();

            return Ok("User registered successfully");
        }
    }
}
