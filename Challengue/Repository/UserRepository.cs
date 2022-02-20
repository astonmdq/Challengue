using Challengue.Contexts;
using Challengue.Entities;
using Challengue.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challengue.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            this._context = context;
        }
        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            var records = await _context.User.Select(x => new UserModel()
            {
                id = x.id,
                nombre = x.nombre,
                apellido = x.apellido,
                email = x.email,
                password = x.password
            }).ToListAsync();

            return records;
        }

        public async Task<int> AddUserAsync(UserModel user)
        {
            var _user = new User()
            {
                nombre = user.nombre,
                apellido = user.apellido,
                email = user.email,
                password = user.password
            };
            _context.User.Add(_user);
            await _context.SaveChangesAsync();
            return _user.id;
        }

        public async Task<UserModel> GetUserByIdAsync(int id)
        {
            var _records = await _context.User.Where(x => x.id == id).Select(x => new UserModel()
            {
                id = x.id,
                nombre = x.nombre,
                apellido = x.apellido,
                password = x.password,
                email = x.email
            }).FirstOrDefaultAsync();
            return _records;
        }

        public async Task UpdateUserAsync(int userId,UserModel user)
        {
            var _user = await _context.User.FindAsync(userId);
            if (_user != null)
            {
                _user.nombre = user.nombre;
                _user.apellido = user.apellido;
                _user.email = user.email;
                _user.password = user.password;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteUserAsync(int userId)
        {
            var _user = new User() { id = userId };
            _context.User.Remove(_user);
            await _context.SaveChangesAsync();
        }
    }
}
