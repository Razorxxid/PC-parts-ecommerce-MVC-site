using e_commerce.Data.Context;
using e_commerce.Data.Repository;
using e_commerce.Models.asbstractClasses;
using System.Collections.Generic;

namespace e_commerce.Services
{
    public class FilteredSearchService
    {
        private readonly ProductContext _context;
        private readonly IProductRepository<AbstractProduct> _productRepository;
        public FilteredSearchService(ProductContext context, IProductRepository<AbstractProduct> productRepository)
        {
            this._context = context;
            _productRepository = productRepository;
        }

        public IEnumerable<AbstractProduct> FilterByName(string name)
        {
            IEnumerable<AbstractProduct> filteredProducts = new List<AbstractProduct>();
            if (name != null)
            {
                filteredProducts = _context.Products.Where(p => p.Name.Contains(name));
            }
            return filteredProducts;
        }
        public async Task <IEnumerable<AbstractProduct>> FilterByCategories(List<String> categories)

        {
            IEnumerable<AbstractProduct> filteredProducts = await _productRepository.GetAllAsync(); 
            IEnumerable<AbstractProduct> originalEnum = filteredProducts;

            for (int i = 0; i < categories.Count; i++)
            {
                filteredProducts = filteredProducts.Concat(originalEnum.Where(
                    p => GetCategoriesFromProduct(p).Contains(categories[i])));
            }   
            
            return filteredProducts;
        }   

        public IEnumerable<AbstractProduct> FilterByPriceRange(int min, int max)
        {
            IEnumerable<AbstractProduct> filteredProducts = new List<AbstractProduct>();
           
            filteredProducts = _context.Products.Where(p => p.Price >= min && p.Price <= max);
            
            return filteredProducts;
        }

        private static List<String> GetCategoriesFromProduct (AbstractProduct product)
        {
            List<String> categories = new();

            if(product.Category != null)
            {
                categories = product.Category.Split(',').ToList();
            }

            return categories;
        }

       


    }


}
