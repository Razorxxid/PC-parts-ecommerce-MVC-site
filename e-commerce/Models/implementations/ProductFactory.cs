using e_commerce.Dtos;
using e_commerce.Models.asbstractClasses;
using e_commerce.Models.implementations;
using e_commerce.Models.interfaces;

namespace e_commerce.Models.implementations
{
    public class ProductFactory : AbstractProductFactory
    {
        public override IProduct GetProduct(string productType)
        {

            return productType switch
            {
                "Processor" => new ProcessorFullDto(),
                "VideoCard" => new VideoCardFullDto(),
                "OtherProducts" => new OtherProducts(),
                _ => throw new System.Exception("Product type not found.")
            };
        }
    }
}
