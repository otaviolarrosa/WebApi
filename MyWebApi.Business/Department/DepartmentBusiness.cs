using MyWebApi.Data.NHibernate.Repository;
using MyWebApi.Interface.Department;
using MyWebApi.Ioc;
using MyWebApi.Models.Department;
using System.Threading.Tasks;
using EntityDepartment = MyWebApi.Mapping.Entities.Department;

namespace MyWebApi.Business.Department
{
    public class DepartmentBusiness : IDepartmentBusiness
    {
        public async Task<DepartmentModel> InsertNewDepartment(DepartmentModel department)
        {
            var id = ServiceLocator.Current.GetInstance<IRepository<EntityDepartment>>().Create(new EntityDepartment { Name = department.Name });
            return new DepartmentModel(1, department.Name);
        }
    }
}
