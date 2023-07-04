using AutoMapper;
using e_commerce.Data.Repository;
using e_commerce.Dtos;
using e_commerce.Models.implementations;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce.Controllers.ProductAdmin.Entities
{
    public class VideoCardAdminController : BaseProductAdminController<VideoCard, string, VideoCardFullDto, IProductRepository<VideoCard>>
    {
        public VideoCardAdminController(IMapper mapper, IProductRepository<VideoCard> repository, ProductFactory factory) : base(mapper, repository, factory)
        {

        }
    }
}
