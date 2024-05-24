using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIGE_INICIO_C__API.Dtos.User;
using SIGE_INICIO_C__API.Helpers;
using SIGE_INICIO_C__API.models;

namespace SIGE_INICIO_C__API.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync(QueryObject query);
        Task<User?> GetByIdAsync(int id);
        Task<User> CreateAsync(User user);
        Task<User?> UpdateAsync(int id, UpdateUserRequestDto userDto);
        Task<User?> DeleteAsync(int id);

    }
}