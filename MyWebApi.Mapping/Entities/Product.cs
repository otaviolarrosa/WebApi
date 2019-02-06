namespace MyWebApi.Mapping.Entities
{
    public class Product : Entity
    {
        public virtual string Name { get; set; }
        public virtual int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
