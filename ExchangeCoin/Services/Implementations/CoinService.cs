using ExchangeCoinApi.Data;
using ExchangeCoinApi.Entities;
using ExchangeCoinApi.Models.DTOs;
using ExchangeCoinApi.Services.Interfaces;

namespace ExchangeCoinApi.Services.Implementations
{
    public class CoinService : ICoinService
    {
        private readonly ExchangeContext _context;

        public CoinService(ExchangeContext context)
        {
            _context = context;
        }
        public List<Coin> GetAllByUser(int id)
        {

            return _context.Coins.Where(c => c.User.Id == id).ToList();
        }

        public void Create(CreateAndUpdateCoin dto, int loggedUserId)
        {
            Coin contact = new Coin()
            {
                Imagen = dto.Imagen,
                Nombre = dto.Nombre,
                Valor = dto.Valor,
                UserId = loggedUserId,
            };
            _context.Coins.Add(contact);
            _context.SaveChanges();
        }

        public void Update(CreateAndUpdateCoin dto, int contactId)
        {
            Coin? contact = _context.Coins.SingleOrDefault(contact => contact.Id == contactId);
            if (contact is not null)
            {
                contact.Imagen = dto.Imagen;
                contact.Nombre = dto.Nombre;
                contact.Valor = dto.Valor;
                _context.SaveChanges();
            }

        }
        public void Delete(int id)
        {
            _context.Coins.Remove(_context.Coins.Single(c => c.Id == id));
            _context.SaveChanges();
        }
    }
}