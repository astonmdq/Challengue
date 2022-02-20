using Challengue.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challengue.Repository
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUsersAsync();
        Task<int> AddUserAsync(UserModel user);

        Task<UserModel> GetUserByIdAsync(int id);

        Task UpdateUserAsync(int userId, UserModel user);

        Task DeleteUserAsync(int userId);
    }
}