using QuanLiNhanSu.Entities;
using QuanLiNhanSu.Models;

namespace QuanLiNhanSu.Repositories.Implements
{
    public class UserRepository : IUserRepository
    {
        public Task<string> AddUserAsync(UserModel model)
        {
            throw new NotImplementedException();
        }

        public Task<User> AddUserEntityAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserModel>> GetAllUserAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetUserByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(string id, UserModel model)
        {
            throw new NotImplementedException();
        }
    }
}
