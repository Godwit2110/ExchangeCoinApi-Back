using ExchangeCoinApi.Models.DTOs;

namespace ExchangeCoinApi.Services.Interfaces
{
    public interface ICoinService
    {
        void Create(CreateAndUpdateCoin dto);
    }
}
