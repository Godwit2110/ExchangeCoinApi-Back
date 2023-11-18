using ExchangeCoinApi.Data;
using ExchangeCoinApi.Entities;
using ExchangeCoinApi.Models.DTOs;

namespace ExchangeCoinApi.Services.Implementations
{
    public class UserService
    {
        private readonly ExchangeContext _context;
        public UserService(ExchangeContext context)
        {
            _context = context;
        }

        public User? GetUsers(int id)
        {
            return _context.Users.SingleOrDefault(c => c.Id == id);
        }
        public bool DeleteUser(int id)
        {
            User? UserDelete = GetUsers(id);
            if (UserDelete != null)
            {
                _context.Users.Remove(UserDelete);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public User UpdateUser(User UserUpdate)
        {
            User? updatedUser = _context.Users.Update(UserUpdate).Entity;
            return updatedUser;
        }

        public int AddUser(User User)
        {
            int userid = _context.Users.Add(User).Entity.Id;
            _context.SaveChanges();
            return userid;
        }

        public User? ValidateUser(AuthenticationRequestBody authRequestBody)
        {
            return _context.Users.FirstOrDefault(p => p.Usuario == authRequestBody.Usuario && p.Contrasenia == authRequestBody.Contrasenia);
        }
    }
}