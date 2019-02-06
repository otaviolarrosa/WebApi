using FluentNHibernate.Mapping;
using MyWebApi.Mapping.Entities;

namespace MyWebApi.Mapping.Mapping
{
    public class DepartmentMap : ClassMap<Department>
    {
        public DepartmentMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
        }
    }
}
