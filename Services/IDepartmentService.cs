using QuanLiNhanSu.Models;

namespace QuanLiNhanSu.Services
{
    public interface IDepartmentService
    {
        public Task<List<DepartmentModel>> GetAllDeps();
        public Task<DepartmentModel> GetDepById(string id);
        public Task<DepartmentModel> AddDep(DepartmentModel userModel);
        //public Task UpdateDep(string id, DepartmentModel model);
        public Task DeleteDep(string id);
    }
}
