namespace MyWebApi.Models.Department
{
    public class DepartmentModel
    {
        public DepartmentModel()
        {

        }

        public DepartmentModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int? Id { get; set; }

        public string Name { get; set; }
    }
}
