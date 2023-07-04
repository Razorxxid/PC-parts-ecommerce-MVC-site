using e_commerce.Models.interfaces;

namespace e_commerce.Models.asbstractClasses
{
    public abstract class AbstractProductFactory
    {
        public abstract IProduct GetProduct(string productType);
        
    }
}
