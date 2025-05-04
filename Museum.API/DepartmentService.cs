using Museum.API.Models;
using Newtonsoft.Json;

namespace Museum.API;

public class DepartmentService : IDepartmentService
{
    private readonly HttpClient client = new HttpClient();
    public async Task<Department[]?> GetDepartments()
    {
        using HttpResponseMessage response = await client.GetAsync($"https://collectionapi.metmuseum.org/public/collection/v1/departments");
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();

        var deparmentsModel = JsonConvert.DeserializeObject<DepartmentsModel>(responseBody);

        return deparmentsModel?.Departments;
    }
}
