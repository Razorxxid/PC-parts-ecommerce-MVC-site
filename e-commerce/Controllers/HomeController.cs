using e_commerce.Data.Context;
using e_commerce.Data.Repository;
using e_commerce.Models;
using e_commerce.Models.asbstractClasses;
using e_commerce.Models.implementations;
using e_commerce.Models.interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AbstractProduct = e_commerce.Models.asbstractClasses.AbstractProduct;

namespace e_commerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IProductRepository<AbstractProduct> _AbstractProductRepository;
 

        
        public HomeController(ILogger<HomeController> logger, IProductRepository<AbstractProduct> productRepository)
        {
            _logger = logger;
           
            _AbstractProductRepository = productRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ProductList()
        {

            return View(_AbstractProductRepository.GetAllAsync());
        }

   


    }
}