using AutoMapper;
using e_commerce.Data.Repository;
using e_commerce.Dtos;
using e_commerce.Models.asbstractClasses;
using e_commerce.Models.implementations;
using e_commerce.Models.interfaces;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace e_commerce.Controllers.ProductAdmin
{
    public class ProductAdminController : Controller
    {

        private readonly IProductRepository<AbstractProduct> _repository;

        private readonly ProductFactory _productFactory;

        private readonly IMapper _mapper;

        public ProductAdminController(IProductRepository<AbstractProduct> repository, ProductFactory factory, IMapper mapper)
        {

            _repository = repository;
            _productFactory = factory;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _repository.GetAllAsync();

            var productsDto = _mapper.Map<List<AbstractProduct>, List<ProductAdminIndexDto>>(products.ToList());

            return products != null ?
                        View(productsDto) :
                        Problem("Entity set 'ProductContext.Products'  is null.");
        }

        // GET: ProductAdmin/Details/5
        public async Task<IActionResult> Details(string id)
        {


            if (id == null)
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
        public IActionResult Create(string dtoType)
        {
            if (dtoType == null)
            {
                return NotFound("El parámetro 'type' no puede ser nulo.");
            }
            return dtoType switch
            {
                "Processor" => RedirectToAction("Create", "ProcessorAdmin", new { type = dtoType }),
                "VideoCard" => RedirectToAction("Create", "VideoCardAdmin", new { type = dtoType }),
                _ => NotFound("failed to match type in Create method, change code"),
            };
        }



        [HttpGet]
        public async Task<IActionResult> Edit(string Id)
        {
            var entity = await _repository.GetByIdAsync(Id);
            if (entity == null)
            {
                return NotFound("Error con ID del producto Edit PM");
            }
            return entity switch
            {
                Processor => RedirectToAction("Edit", "ProcessorAdmin", new { id = Id }),
                VideoCard => RedirectToAction("Edit", "VideoCardAdmin", new { id = Id }),
                _ => NotFound("failed to match type in Edit method, change code"),
            };
        }



        // GET: ProductAdmin/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
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

        // POST: ProductAdmin/Delete/5
        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(string id)
        {

            var abstractProduct = await _repository.GetByIdAsync(id);
            if (abstractProduct != null)
            {
                _repository.DeletebyId(id);
            }

            await _repository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private async Task<bool> AbstractProductExists(string id)
        {
            return await _repository.GetByIdAsync(id) != null;
        }
    }
}
