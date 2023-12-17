using ExchangeCoinApi.Data;
using ExchangeCoinApi.Entities;
using ExchangeCoinApi.Models.DTOs;

namespace ExchangeCoinApi.Services.Implementations
{
    public class UserService
    {
        private readonly ExchangeContext _exchangeContext;
        public UserService(ExchangeContext context)
        {
            _exchangeContext = context;
        }
        public User? ValidateUser(AuthenticationRequestBody authRequestBody)
        {
            return _exchangeContext.usuario.FirstOrDefault(p => p.Usuario == authRequestBody.Usuario && p.Contrasenia == authRequestBody.Contrasenia);
        }

        public void Create(CreateAndUpdateUserDto dto)
        {
            User newUser = new User()
            {
                Nombre = dto.Nombre,
                Usuario = dto.Usuario,
                Email = dto.Email,
                Contrasenia = dto.Contrasenia,
                Suscripcion = Suscripcion.Free,
                TotalConversiones = 10
            };
            _exchangeContext.usuario.Add(newUser);
            _exchangeContext.SaveChanges();
        }
    }
}
