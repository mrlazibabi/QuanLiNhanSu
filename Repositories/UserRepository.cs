using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuanLiNhanSu.Entities;
using QuanLiNhanSu.Models;
using SQLitePCL;

namespace QuanLiNhanSu.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly QuanLiNhansu1Context _context;
        private readonly IMapper _mapper;

        public UserRepository(QuanLiNhansu1Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //GET ALL
        public async Task<List<UserModel>> GetAllUserAsync()
        {
            var users = await _context.Users!.ToListAsync();
            return _mapper.Map<List<UserModel>>(users);

        }

        //GET BY ID
        public async Task<UserModel> GetUserByIdAsync(string id)
        {
            var user = await _context.Users!.FindAsync(id);
            return _mapper.Map<UserModel>(user);

        }

        //POST
        public async Task<string> AddUserAsync(UserModel model)
        {
            var newUser = _mapper.Map<User>(model);
            _context.Users!.Add(newUser);
            await _context.SaveChangesAsync();

            return newUser.Id;

        }

        //PUT
        public async Task UpdateUserAsync(string id, UserModel model)
        {
            if (id == model.Id)
            {
                var updateUser = _mapper.Map<User>(model);
                _context.Users!.Update(updateUser);
                await _context.SaveChangesAsync();
            }
        }

        //DELETE
        public async Task DeleteUserAsync(string id)
        {
            var deleteUser = _context.Users!.SingleOrDefault(x => x.Id == id);
            if (deleteUser != null)
            {
                _context.Users!.Remove(deleteUser);
                await _context.SaveChangesAsync();
            }

        }
    }
}
