using e_commerce.Models.asbstractClasses;

namespace e_commerce.Dtos
{
    public class SearchDto 
    {
        private  string? _id;
        private  string? _name;
        private  string? _price;

        public string? Id { get => _id; set => _id = value; }
        public string? Name { get => _name; set => _name = value; }
        public string? Price { get => _price; set => _price = value; }
    }
}
