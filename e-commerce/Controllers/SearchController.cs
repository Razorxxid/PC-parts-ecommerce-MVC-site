using AutoMapper;
using e_commerce.Data.Repository;
using e_commerce.Dtos;
using e_commerce.Models.asbstractClasses;
using e_commerce.Models.interfaces;
using e_commerce.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace e_commerce.Controllers
{
    public class SearchController : Controller
    {
        
        private readonly FilteredSearchService _filteredSearchService;

        private  List<AbstractProduct> _products;

        private readonly IMapper _mappper;

        public SearchController(FilteredSearchService filteredSearchService, List<AbstractProduct> products, IMapper mappper)
        {

            _filteredSearchService = filteredSearchService;
            _products = products;
            _mappper = mappper;
        }

        [HttpPost, ActionName("SearchByName")]

        public IActionResult SearchByName(string searchString)
        {
            
            _products =  _filteredSearchService.FilterByName(searchString).ToList();

            var productsDto = _mappper.Map<List<AbstractProduct>, List<SearchDto>>(_products);

            return View("SearchList", productsDto);
        }

        [HttpPost, ActionName("SearchByCategories")]

        public async Task <IActionResult> SearchByCategories(List<string> categories)
        {

            _products = (List<AbstractProduct>) await _filteredSearchService.FilterByCategories(categories); 

            var productsDto = _mappper.Map<List<AbstractProduct>, List<SearchDto>>(_products);

            return View("SearchList", productsDto);
        }
    }
}
