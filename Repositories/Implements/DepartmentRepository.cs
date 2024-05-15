using QuanLiNhanSu.Entities;
using QuanLiNhanSu.Models;

namespace QuanLiNhanSu.Repositories.Implements
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public Task<string> AddDep(DepartmentModel model)
        {
            throw new NotImplementedException();
        }

        public Task<Department> AddDepEntityAsync(Department dep)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDep(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<DepartmentModel>> GetAllDep()
        {
            throw new NotImplementedException();
        }

        public Task<Department> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<DepartmentModel> GetDepById(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDep(string id, DepartmentModel model)
        {
            throw new NotImplementedException();
        }
    }
}
