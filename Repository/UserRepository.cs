using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SIGE_INICIO_C__API.data;
using SIGE_INICIO_C__API.Dtos.User;
using SIGE_INICIO_C__API.Helpers;
using SIGE_INICIO_C__API.Interfaces;
using SIGE_INICIO_C__API.models;

namespace SIGE_INICIO_C__API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DBContext _context;
        public UserRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> DeleteAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
            if (user == null)
            {
                return null;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllAsync(QueryObject query)
        {
            var users = _context.Users.AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                users = users.Where(x => x.Name.Contains(query.Name));
            }
            if (!string.IsNullOrWhiteSpace(query.LastName))
            {
                users = users.Where(x => x.LastName.Contains(query.LastName));
            }
            return await users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> UpdateAsync(int id, UpdateUserRequestDto userDto)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
            if (existingUser == null)
            {
                return null;
            }
            existingUser.UserId = userDto.UserId;
            existingUser.Name = userDto.Name;
            existingUser.LastName = userDto.LastName;
            existingUser.Privileges = userDto.Privileges;
            existingUser.Password = userDto.Password;
            existingUser.Areas = userDto.Areas;

            await _context.SaveChangesAsync();
            return existingUser;
        }
    }
}