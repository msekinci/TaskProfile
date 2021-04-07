using Microsoft.AspNetCore.Mvc;
using MSE.TaskProfile.Business.Interfaces;
using MSE.TaskProfile.Entities.Concrete;
using MSE.TaskProfile.WebApi.Helpers;
using System.Threading.Tasks;

namespace MSE.TaskProfile.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IGenericService<User> _userService;

        public UsersController(IGenericService<User> userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.ID = HelperClass.GenerateTCIdentifier();
                await _userService.Create(user);
                return Created("", user);
            }
            return ValidationProblem();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Read(long id)
        {
            var readUser = await _userService.Read(id);
            if (readUser != null)
            {
                return Ok(readUser);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, User user)
        {
            if (ModelState.IsValid)
            {
                var readUser = await _userService.Read(id);
                if (readUser != null && user.ID == id)
                {
                    await _userService.Update(user);
                    return NoContent();
                }
                return NotFound();
            }
            return ValidationProblem();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            if (ModelState.IsValid)
            {
                var readUser = await _userService.Read(id);
                if (readUser != null)
                {
                    await _userService.Delete(readUser);
                    return NoContent();
                }
                return NotFound();
            }
            return ValidationProblem();
        }
    }
}
