

using e_commerce.Data.Context;
using e_commerce.Data.Repository;
using e_commerce.Models.asbstractClasses;
using e_commerce.Services;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Xunit;
using Xunit.Abstractions;
using e_commerce.Models.implementations;
using e_commerce.Models.interfaces;
using e_commerce.Controllers;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using e_commerce.Mapper;
using Moq;
using e_commerce.Dtos;

namespace TestProjectEcommerce
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper output;
        private readonly IMapper _mapper;

        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MapperProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [Fact]
        public void Test1()
        {


          



            var dbOptions = new DbContextOptionsBuilder<ProductContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString());

            ProductContext context = new(dbOptions.Options);


            IProductRepository<AbstractProduct> _productRepository = new ProductRepository<AbstractProduct>(context);

            AbstractProduct producto = new Processor();
            producto.Name = "I7";
            producto.Category = "Procesador";
            producto.Description = "Procesador de 8 nucleos";
            
            _productRepository.AddAsync(producto);
            _productRepository.SaveChangesAsync();

            AbstractProduct producto2 = new Processor();
            producto2.Name = "I9";
            producto2.Category = "Procesador, GAMA ALTA,";
            producto2.Description = "Procesador de 12 nucleos";

            _productRepository.AddAsync(producto2);
            _productRepository.SaveChangesAsync();

            List<AbstractProduct> lista = new List<AbstractProduct>();  
            
            var searchService = new FilteredSearchService(context, _productRepository);

            

            lista = searchService.FilterByName("I7").ToList();

            List<SearchDto> listaAutoMapper = _mapper.Map<List<AbstractProduct>, List<SearchDto>>(lista);

            if (listaAutoMapper != null)
            output.WriteLine(listaAutoMapper[0].Name);

            Assert.IsType<List<AbstractProduct>>(lista);





        }
    }
}