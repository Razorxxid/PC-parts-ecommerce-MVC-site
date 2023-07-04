using AutoMapper;
using e_commerce.Dtos;
using e_commerce.Models.asbstractClasses;
using e_commerce.Models.implementations;

namespace e_commerce.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Processor, ProcessorFullDto>().ReverseMap();
            CreateMap<VideoCard, VideoCardFullDto>().ReverseMap();
            CreateMap<AbstractProduct, SearchDto>().ReverseMap();
            CreateMap<AbstractProduct, ProductAdminIndexDto>().ReverseMap();
        }
    }
}
