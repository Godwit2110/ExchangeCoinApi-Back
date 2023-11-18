using ExchangeCoinApi.Data;
using ExchangeCoinApi.Data.Entiities;

namespace ExchangeCoinApi.Services.Implementations
{
    public class CoinService
    {
        private readonly ExchangeContext _context;
        public CoinService(ExchangeContext context)
        {
            _context = context;
        }

        public Coin? GetCoins(int id)
        {
            return _context.Coins.SingleOrDefault(c => c.Id == id);
        }
        public bool DeleteCoin(int id)
        {
            Coin? CoinDelete = GetCoins(id);
            if (CoinDelete != null)
            {
                _context.Coins.Remove(CoinDelete);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Coin UpdateCoin(Coin CoinUpdate)
        {
            Coin? updatedCoin = _context.Coins.Update(CoinUpdate).Entity;
            return updatedCoin;
        }

        public int AddCoin(Coin Coin)
        {
            int contactid = _context.Coins.Add(Coin).Entity.Id;
            _context.SaveChanges();
            return contactid;
        }
    }
}
