using FluentNHibernate.Mapping;
using MyWebApi.Mapping.Entities;

namespace MyWebApi.Data.NHibernate.DatabaseMapping
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            References(c => c.Department);
            Map(x => x.DepartmentId).Formula("Department_id");
        }
    }
}
