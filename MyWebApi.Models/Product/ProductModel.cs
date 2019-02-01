namespace MyWebApi.Models.Product
{
    public class ProductModel
    {
        public ProductModel() { }

        public ProductModel(string name)
        {
            Name = name;
        }

        public ProductModel(int? id, string name)
        {
            Id = id;
            Name = name;
        }

        public int? Id { get; set; }

        public string Name { get; set; }
    }
}
