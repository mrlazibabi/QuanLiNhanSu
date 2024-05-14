using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuanLiNhanSu.Entities;
using QuanLiNhanSu.Models;
using QuanLiNhanSu.Repositories;


namespace QuanLiNhanSu.Services.Implements;

public class UserService : IUserService
{
    private readonly QuanLiNhansu1Context _context;
    private readonly IUserRepository _userRepo;
    private readonly IMapper _mapper;
    private readonly IDepartmentRepository _depRepo;
    private readonly IRoleRepository _roleRepo;

    public UserService(QuanLiNhansu1Context context, IUserRepository userRepo, IMapper mapper, IDepartmentRepository depRepo,
        IRoleRepository roleRepo)
    {
        _context = context;
        _userRepo = userRepo;
        _mapper = mapper;
        _depRepo = depRepo;
        _roleRepo = roleRepo;
    }

    // GET ALL Service
    public async Task<List<UserModel>> GetAllUser()
    {
        var users = await _context.Users!.ToListAsync();
        return _mapper.Map<List<UserModel>>(users);

    }

    // GET BY ID Service
    public async Task<UserModel> GetUserById(string id)
    {
        var user = await _context.Users!.FindAsync(id);
        return _mapper.Map<UserModel>(user);

    }

    // POST Service
    public async Task<UserModel> AddUser(UserModel userModel)
    {
        try
        {
            var userEntity = _mapper!.Map<User>(userModel);
            userEntity.Dep = (await _depRepo!.GetDepById(userModel.DepId)).Result;
            userEntity.Role = _roleRepo.GetById(userModel.RoleId).Result;
            await _userRepo.AddUserEntityAsync(userEntity);
            return _mapper!.Map<UserModel>(userEntity);
        }
        catch (Exception)
        {
            return null;
        }
    }

    // PUT Service
    public async Task UpdateUser(string id, UserModel model)
    {
        if (id == model.Id)
        {
            var updateUser = _mapper.Map<User>(model);
            _context.Users!.Update(updateUser);
            await _context.SaveChangesAsync();
        }
    }

    // DELETE Service
    public async Task DeleteUser(string id)
    {
        var deleteUser = _context.Users!.SingleOrDefault(x => x.Id == id);
        if (deleteUser != null)
        {
            _context.Users!.Remove(deleteUser);
            await _context.SaveChangesAsync();
        }

    }

}