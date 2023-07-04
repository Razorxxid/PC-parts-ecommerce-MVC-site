using System.Xml.Linq;

namespace e_commerce.Models.interfaces
{
    public interface IProduct
    {
        string Id { set; get; }
        string? Name { set; get; }
        string? Manufacter { set; get; }
        string? Description { set; get; }
        double Price { set; get; }
        string? Category { set; get;}
        void AddCategory(string category);
        void RemoveCategory(string category);

    }
}
