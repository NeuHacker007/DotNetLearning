using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PocketBook.Core.IConfiguration;
using PocketBook.Models;

namespace PocketBook.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(
            ILogger<UsersController> logger,
            IUnitOfWork unitOfWork
        )
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                user.Id = Guid.NewGuid();

                await _unitOfWork.userRepository.Add(user);
                await _unitOfWork.CompleteAsync();

                return CreatedAtAction("GetItem", new { user.Id }, user);
            }

            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }


        public async Task<IActionResult> GetItem(Guid id)
        {
            var user = await _unitOfWork.userRepository.GetById(id);
            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _unitOfWork.userRepository.All();

            return Ok(users);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateItem(Guid id, User user)
        {
            if (id != user.Id) return BadRequest();
            await _unitOfWork.userRepository.Upsert(user);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            var item = await _unitOfWork.userRepository.GetById(id);

            if (item == null) return BadRequest();

            await _unitOfWork.userRepository.Delete(id);
            await _unitOfWork.CompleteAsync();

            return Ok(id);
        }
    }
}