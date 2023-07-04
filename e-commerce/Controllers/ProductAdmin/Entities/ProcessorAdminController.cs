
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using e_commerce.Models.asbstractClasses;
using e_commerce.Models.implementations;
using e_commerce.Models.interfaces;
using e_commerce.Data.Repository;
using System.Reflection;
using System.Diagnostics;
using e_commerce.Dtos;
using AutoMapper;

namespace e_commerce.Controllers.ProductAdmin.Entities
{
    public class ProcessorAdminController : BaseProductAdminController<Processor, string, ProcessorFullDto, IProductRepository<Processor>>
    {
        public ProcessorAdminController(IMapper mapper, IProductRepository<Processor> repository, ProductFactory factory) : base(mapper, repository, factory)
        {
        }
    }
}
