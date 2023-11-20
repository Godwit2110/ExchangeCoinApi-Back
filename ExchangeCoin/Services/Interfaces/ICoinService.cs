using ExchangeCoinApi.Entities;
using ExchangeCoinApi.Models.DTOs;

namespace ExchangeCoinApi.Services.Interfaces
{
    public interface ICoinService
    {
        void Create(CreateAndUpdateCoin dto);
        void Delete(int id);
        List<Coin> GetAllByUser(int Id);
        void Update(CreateAndUpdateCoin dto, int coinid);
    }
}
