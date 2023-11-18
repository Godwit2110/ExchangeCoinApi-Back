using ExchangeCoinApi.Entities;
using ExchangeCoinApi.Models.DTOs;

namespace ExchangeCoin.Services.Interfaces
{
    public interface IUserService
    {
        void Create(CreateAndUpdateUserDto dto);

        User? ValidateUser(AuthenticationRequestBody authRequestBody);
    }
}