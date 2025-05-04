using Newtonsoft.Json;

namespace Museum.API.Models;

public  class DepartmentsModel
{
    [JsonProperty("departments")]
    public Department[]? Departments { get; set; }
}

public  class Department
{
    [JsonProperty("departmentId")]
    public long DepartmentId { get; set; }

    [JsonProperty("displayName")]
    public string? DisplayName { get; set; }
}