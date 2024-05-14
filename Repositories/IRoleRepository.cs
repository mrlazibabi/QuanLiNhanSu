using QuanLiNhanSu.Entities;

namespace QuanLiNhanSu.Repositories;

public interface IRoleRepository
{
    public Task<Role> GetById(int id);
}