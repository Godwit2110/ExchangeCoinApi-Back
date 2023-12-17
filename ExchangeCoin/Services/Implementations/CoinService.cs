using ConversionDeMonedas.Data;
using ConversionDeMonedas.Entities;
using ConversionDeMonedas.Models.Dtos;
using System.Xml.Linq;
using System;
using ExchangeCoinApi.Data;
using ExchangeCoin.Models;
using ExchangeCoinApi.Entities;
using ExchangeCoinApi.Models.DTOs;

namespace ExchangeCoinApi.Services.Implementations
{
    public class CoinService
    {
        private readonly ExchangeContext _exchangecontext;
        public CoinService(ExchangeContext context)
        {
            _exchangecontext = context;
        }

        public double Convert(User usuario, double amount, ConvertProcess toConvert)
        {
            double result = amount * toConvert.VelorConvertido / toConvert.ValorParaConvertir;
            return result;
        }

        public void CreateCoin(int LoggeduserId, CreateAndUpdateCoin dto)
        {
            Coin newCoin = new Coin()
            {
                Nombre = dto.Nombre,
                Imagen = dto.Imagen,
                Valor = dto.Valor,
                UserId = LoggeduserId

            };
            _exchangecontext.monedasUser.Add(newCoin);
            _exchangecontext.SaveChanges();
        }

        public void UpdateCoin(int monedaId, string leyenda, CreateAndUpdateCoin dto)
        {
            Coin? coinToUpdate = _exchangecontext.monedasUser.SingleOrDefault(c => c.Id == monedaId);
            Favoritas? coinFavToUpdate = _exchangecontext.Favoritas.SingleOrDefault(f => f.Nombre == Nombre);

            if (coinToUpdate is not null)
            {
                //edit user coin 
                coinToUpdate.Leyenda = dto.Leyenda;
                coinToUpdate.Simbolo = dto.Simbolo;
                coinToUpdate.IC = dto.IC;

                if (coinFavToUpdate is not null)
                {
                    //edit fav coin
                    coinFavToUpdate.Leyenda = dto.Leyenda;
                    coinFavToUpdate.Simbolo = dto.Simbolo;
                    coinFavToUpdate.IC = dto.IC;
                }
                _exchangecontext.SaveChanges();
            }
            else
            {
                Console.WriteLine("El Id no coincide");
            }
        }
        public void DeleteCoin(int monedaId, string leyenda)
        {
            Favoritas? coinFavToDelete = _exchangecontext.Favoritas.SingleOrDefault(f => f.Leyenda == leyenda);
            if (coinFavToDelete is not null)
            {
                _CDMContext.Favoritas.Remove(coinFavToDelete);
            }
            _exchangecontext.monedasUser.Remove(_exchangecontext.monedasUser.Single(c => c.Id == monedaId));
            _exchangecontext.SaveChanges();
        }

        public void AddFavCoin(int LoggeduserId, AddFavoriteDto dto)
        {
            List<Favoritas> coins = _exchangecontext.Favoritas.Where(u => u.Id == LoggeduserId).ToList();

            bool esta = false;

            foreach (Favoritas coin in coins)
            {
                if (dto.Leyenda == coin.Leyenda)
                {
                    esta = true;
                    break;
                }
            }

            if (esta == false)
            {
                Favoritas newFav = new Favoritas()
                {
                    Leyenda = dto.Leyenda,
                    Simbolo = dto.Simbolo,
                    IC = dto.IC,
                    UserId = LoggeduserId
                };
                _exchangecontext.Favoritas.Add(newFav);
                _exchangecontext.SaveChanges();
            }
            else
            {
                Console.WriteLine("Esa moneda ya esta en favoritos");
            }
        }

        public void DeleteFavCoin(int monedaId)
        {
            _exchangecontext.Favoritas.Remove(_exchangecontext.Favoritas.Single(c => c.Id == monedaId));
            _exchangecontext.SaveChanges();
        }
    }
}
