using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuanLiNhanSu.Entities;
using QuanLiNhanSu.Models;
using QuanLiNhanSu.Repositories;

namespace QuanLiNhanSu.Services.Implements
{
    public class DepartmentService : IDepartmentService
    {
        private readonly QuanLiNhansu1Context _context;
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _depRepo;
        

        public DepartmentService(QuanLiNhansu1Context context, IMapper mapper, IDepartmentRepository depRepo,
            IRoleRepository roleRepo)
        {
            _context = context;
            _mapper = mapper;
            _depRepo = depRepo;
        }

        // GET ALL Service
        public async Task<List<DepartmentModel>> GetAllDeps()
        {
            var deps = await _context.Departments!.ToListAsync();
            return _mapper.Map<List<DepartmentModel>>(deps);

        }

        // GET BY ID Service
        public async Task<DepartmentModel> GetDepById(string id)
        {
            var dep = await _context.Departments!.FindAsync(id);
            return _mapper.Map<DepartmentModel>(dep);

        }

        // POST Service
        public async Task<DepartmentModel> AddDep(DepartmentModel depModel)
        {
            try
            {
                var depEntity = _mapper!.Map<Department>(depModel);
                await _depRepo.AddDepEntityAsync(depEntity);
                return _mapper!.Map<DepartmentModel>(depEntity);
            }
            catch (Exception)
            {
                return null;
            }
        }

        // PUT Service
        //public async Task UpdateDep(string id, DepartmentModel model)
        //{
        //    if (id == model.Id)
        //    {
        //        var updateDep = _mapper.Map<DepartmentModel>(model);
        //        _context.Departments!.Update(updateDep);
        //        await _context.SaveChangesAsync();
        //    }
        //}

        // DELETE Service
        public async Task DeleteDep(string id)
        {
            var deleteDep = _context.Departments!.SingleOrDefault(x => x.Id == id);
            if (deleteDep != null)
            {
                _context.Departments!.Remove(deleteDep);
                await _context.SaveChangesAsync();
            }

        }
    }
}
