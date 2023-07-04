using AutoMapper;
using e_commerce.Data.Repository;
using e_commerce.Models.asbstractClasses;
using e_commerce.Models.implementations;
using e_commerce.Models.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace e_commerce.Controllers.ProductAdmin
{


    public abstract class BaseProductAdminController<TE, TI, TD, TR> : Controller where TE : IProduct where TR : IProductRepository<TE>
    {
        // inyectar el automapper
        private readonly IMapper _imapper;
        private readonly TR _repository;
        private readonly ProductFactory _factory;


        public BaseProductAdminController(IMapper mapper, TR repository, ProductFactory factory)
        {
            _imapper = mapper;
            _repository = repository;
            _factory = factory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _repository.GetAllAsync();

            return products != null ?
                        View(products) :
                        Problem("Entity set 'ProductContext.Products'  is null.");
        }

        // GET: ProductAdmin/Details/5S
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var products = await _repository.GetAllAsync();

            if (id == null || products == null)
            {
                return NotFound();
            }

            var abstractProduct = await _repository.GetByIdAsync(id);
            if (abstractProduct == null)
            {
                return NotFound();
            }


            return View(abstractProduct);
        }

        [HttpGet]
        public IActionResult Create(string type)
        {
            var newEntity = _factory.GetProduct(type);
            return View("~/Views/ProductAdmin/Create.cshtml", newEntity);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(TD dto)
        {

            var entity = _imapper.Map<TD, TE>(dto);

            try
            {
                await _repository.AddAsync(entity);
                await _repository.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException("Failed to add and changes to the database.");
            }

            return RedirectToAction("Index", "ProductAdmin");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {

            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
            {
                return NotFound("Error con ID del producto base");
            }

            var dto = _imapper.Map<TE, TD>(entity);

            return View("~/Views/ProductAdmin/Edit.cshtml", dto);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(TD dto)
        {

            var entity = _imapper.Map<TD, TE>(dto);

            try
            {
                _repository.Update(entity);
                await _repository.SaveChangesAsync();
            }

            catch (DbUpdateException)
            {
                throw new DbUpdateException("Failed to update and save changes to the database.");
            }

            return RedirectToAction("Index", "ProductAdmin");
        }

    }
}
