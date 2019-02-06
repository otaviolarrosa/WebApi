using MyWebApi.Models.Department;
using System.Threading.Tasks;

namespace MyWebApi.Interface.Department
{
    public interface IDepartmentBusiness
    {
        Task<DepartmentModel> InsertNewDepartment(DepartmentModel department);
    }
}
