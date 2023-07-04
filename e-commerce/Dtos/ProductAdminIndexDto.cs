namespace e_commerce.Dtos
{
    public class ProductAdminIndexDto
    {
        private string? _id;

        private string? _category;

        private string? _name;
    
        private string? _price;


        private string? _manufacter;

        public string? Id { get => _id; set => _id = value; }
        public string? Category { get => _category; set => _category = value; }
        public string? Name { get => _name; set => _name = value; }
        public string? Price { get => _price; set => _price = value; }
        public string? Manufacter { get => _manufacter; set => _manufacter = value; }
    }
}
