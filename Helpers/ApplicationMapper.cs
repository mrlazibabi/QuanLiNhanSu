using AutoMapper;
using QuanLiNhanSu.Entities;
using QuanLiNhanSu.Models;

namespace QuanLiNhanSu.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<UserModel, User>().ReverseMap();
            CreateMap<DepartmentModel, Department>().ReverseMap();
        }
    }
}
