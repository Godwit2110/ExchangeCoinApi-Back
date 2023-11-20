using ExchangeCoin.Services.Interfaces;
using ExchangeCoinApi.Models.DTOs;
using ExchangeCoinApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeCoinApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CoinController : ControllerBase
    {
        private readonly ICoinService _coinService;
        private readonly IUserService _userService;

        public CoinController(ICoinService coinService, IUserService userRepository)
        {
            _coinService = coinService;
            _userService = userRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
            return Ok(_coinService.GetAllByUser(userId));
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
            return Ok(_coinService.GetAllByUser(userId).Where(x => x.Id == id));
        }


        [HttpPost]
        public IActionResult CreateCoin(CreateAndUpdateCoin createCoinDto)
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
            _coinService.Create(createCoinDto, userId);
            return Created("Created", createCoinDto);
        }

        [HttpPut]
        [Route("{Id}")]
        public IActionResult UpdateContact(CreateAndUpdateCoin dto, int contactId)
        {
            _coinService.Update(dto, contactId);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var role = HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("role"));
            if (role.Value == "Admin")
            {
                _userService.Delete(id);
            }
            else
            {
                _userService.Archive(id);
            }
            return NoContent();
        }

    }
}