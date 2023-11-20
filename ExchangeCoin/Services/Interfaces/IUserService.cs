using ExchangeCoinApi.Entities;
using ExchangeCoinApi.Models.DTOs;

namespace ExchangeCoin.Services.Interfaces
{
    public interface IUserService
    {
        void Archive(int id);
        bool CheckIfUserExists(int userId);
        void Create(CreateAndUpdateUserDto dto);
        void Delete(int id);
        List<User> GetAll();
        User? GetById(int userId);
        void Update(CreateAndUpdateUserDto dto, int userId);
        User? ValidateUser(AuthenticationRequestBody authRequestBody);
    }
}