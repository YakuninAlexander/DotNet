using System.Globalization;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using create_test.Entities.Models;
using create_test.Repository;
using Microsoft.AspNetCore.Mvc;

namespace create_tests.WebAPI.Controllers
{
    /// <summary>
    /// Doctors endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IRepository<User> _repository;

        /// <summary>
        /// Users controller
        /// </summary>
        public UsersController(IRepository<User> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUsers()
        {
            var user1 = new User()
            {
                Login = "Sasha",
                PasswordHash = "Moscow",
            };

            var user2 = new User()
            {
                Login = "Masha",
                PasswordHash = "Moscow",
            };

            try
            {
                user1 = _repository.Save(user1);
                user2 = _repository.Save(user2);
            }
            catch(Exception e)
            {

            }

            var users = _repository.GetAll();
            return Ok(users);
        }
    }
}