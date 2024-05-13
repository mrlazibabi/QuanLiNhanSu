using QuanLiNhanSu.Entities;
using QuanLiNhanSu.Models;

namespace QuanLiNhanSu.Repositories
{
    public interface IUserRepository
    {
        public Task<List<UserModel>>GetAllUserAsync();
        public Task<UserModel> GetUserByIdAsync(string id);
        public Task<string> AddUserAsync(UserModel model);
        public Task UpdateUserAsync(string id, UserModel model);
        public Task DeleteUserAsync(string id);
    }
}
