

using AutoMapper;
using DOMAIN.Models;
using DTO.Models;

namespace DTO.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Book, BookCreateDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryCreateDTO>().ReverseMap();



            CreateMap<Report, ReportDTO>().ReverseMap();
            CreateMap<Report, ReportCreateDTO>().ReverseMap();
            CreateMap<Report, ReportUpdateDTO>().ReverseMap();
            CreateMap<Directorate, DirectorateDTO>().ReverseMap();
            CreateMap<Directorate, DirectorateCreateDTO>().ReverseMap();
        }
    }
}
