
using Museum.API.Models;

namespace Museum.API
{
    public interface IDepartmentService
    {
        Task<Department[]?> GetDepartments();
    }
}