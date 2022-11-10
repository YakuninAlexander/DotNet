using System.Globalization;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using create_test.Entities.Models;
using create_test.Repository;
using Microsoft.AspNetCore.Mvc;

namespace TrainTimetable.WebAPI.Controllers
{
    /// <summary>
    /// Doctors endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TrainsController : ControllerBase
    {
        private IRepository<User> _repository;

        /// <summary>
        /// Trains controller
        /// </summary>
        public TrainsController(IRepository<User> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get trains
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetTrains()
        {
            var train1 = new User()
            {
                Login = "Sasha",
                PasswordHash = "Moscow",
            };

            var train2 = new User()
            {
                Login = "Masha",
                PasswordHash = "Moscow",
            };

            try
            {
                train1 = _repository.Save(train1);
                train2 = _repository.Save(train2);
            }
            catch(Exception e)
            {

            }

            var users = _repository.GetAll();
            return Ok(users);
        }
    }
}