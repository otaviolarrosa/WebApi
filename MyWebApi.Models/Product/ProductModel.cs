namespace MyWebApi.Models.Product
{
    public class ProductModel
    {
        public ProductModel() { }

        public ProductModel(string name)
        {
            Name = name;
        }

        public ProductModel(int? id, string name, int? departmentId)
        {
            Id = id;
            Name = name;
            DepartmentId = departmentId;
        }

        public int? Id { get; set; }

        public string Name { get; set; }
        public int? DepartmentId { get; set; }
    }
}
