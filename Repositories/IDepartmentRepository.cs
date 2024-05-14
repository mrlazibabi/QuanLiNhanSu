using QuanLiNhanSu.Entities;
using QuanLiNhanSu.Models;

namespace QuanLiNhanSu.Repositories;

public interface IDepartmentRepository
{
    public Task<Department> AddDepEntityAsync(Department dep);
    public Task<List<DepartmentModel>> GetAllDep();
    public Task<DepartmentModel> GetDepById(string id);
    public Task<string> AddDep(DepartmentModel model);
    public Task UpdateDep(string id, DepartmentModel model);
    public Task DeleteDep(string id);
}