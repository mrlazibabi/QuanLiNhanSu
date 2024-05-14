using QuanLiNhanSu.Entities;
using QuanLiNhanSu.Models;

namespace QuanLiNhanSu.Services;

public interface IUserService
{
    public Task<List<UserModel>> GetAllUser();
    public Task<UserModel> GetUserById(string id);
    public Task<UserModel> AddUser(UserModel userModel);
    public Task UpdateUser(string id, UserModel model);
    public Task DeleteUser(string id);

}