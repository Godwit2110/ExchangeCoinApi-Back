using AgendaApi.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

using ConversionDeMonedas.Models.Dtos;
using ConversionDeMonedas.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeCoinApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("RegistrodeUsuario")]
        public IActionResult Create(CreateUserDto dto)
        {
            try
            {
                _userService.Create(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok("Creado correctamente");
        }
        [HttpPost("AgregarFavorita")]

        public IActionResult AddFavCoin(AddFavoriteDto favDto)
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
            try
            {
                _coinService.AddFavCoin(userId, favDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok("Agregada Correctamente");
        }

        [HttpDelete("BorrarFavorita")]

        public IActionResult DeleteFavCoin(int monedaId)
        {
            try
            {
                _coinService.DeleteFavCoin(monedaId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok("Eliminada correctamente");
        }
    }
}
