using QuanLiNhanSu.Entities;

namespace QuanLiNhanSu.Repositories;

public interface IDepartmentRepository
{
    public Task<Department> GetById(string id);
}