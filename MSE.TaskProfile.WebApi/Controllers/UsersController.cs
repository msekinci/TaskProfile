using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MSE.TaskProfile.Business.Interfaces;
using MSE.TaskProfile.Entities.Concrete;
using MSE.TaskProfile.WebApi.Helpers;
using MSE.TestProfile.DTO.Concrete.UserDTOs;
using System.Threading.Tasks;

namespace MSE.TaskProfile.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IGenericService<User> _userService;
        private readonly IMapper _mapper;

        public UsersController(IGenericService<User> userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserCreateDTO userCreateDTO)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<User>(userCreateDTO);
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
                return Ok(_mapper.Map<UserGetDTO>(readUser));
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id,[FromBody] UserUpdateDTO userUpdateDTO)
        {
            if (ModelState.IsValid)
            {
                var readUser = await _userService.Read(id);
                if (readUser != null && userUpdateDTO.ID == id)
                {
                    await _userService.Update(_mapper.Map<User>(userUpdateDTO));
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
