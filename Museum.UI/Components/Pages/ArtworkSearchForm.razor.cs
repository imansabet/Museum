using Microsoft.AspNetCore.Components;
using Museum.API;
using Museum.API.Models;

namespace Museum.UI.Components.Pages;

public partial class ArtworkSearchForm
{
    [Inject]
    public IDepartmentService _departmentService { get; set; } = default!;
    [Inject]
    public IArtworkService  _artworkService { get; set; } = default!;



    List<Department>? _departments { get; set; } = default!;

    long _selectedDepartmentId { get; set; }

    List<string>? _matchingArtworkIds { get; set; }
    int? _currentArtworkIndex { get; set; }

    private const string Department = "Department";
    private const string keyword = "keyword";

    List<string> _searchOptions { get; set; } = new List<string> { Department, keyword };

    string _selectedSearchOption { get; set; } = Department;

    string? _currentKeyword { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _departments = (await _departmentService.GetDepartments())?.ToList();
        _departments?.Insert(0, new Department { DepartmentId = 0, DisplayName = " Please Select " });
    }

    public async Task GetArtWorkByDepartmentId() 
    {
        _matchingArtworkIds = await _artworkService.GetArtworkIdsByDepartment(_selectedDepartmentId);
        _currentArtworkIndex = 0;
    }
    public void GetPreviousArtwork() 
    { 
        if(_currentArtworkIndex > 0)
            _currentArtworkIndex--;
    }

    public void GetNextArtwork() 
    {
        if(_matchingArtworkIds is not null && _currentArtworkIndex < (_matchingArtworkIds.Count() - 1))
            _currentArtworkIndex++;
    }

    protected void OnCheckedValueChanged(string value) 
    {
        _matchingArtworkIds = null;
        _currentArtworkIndex = null;
        _selectedSearchOption = value;
    }

    protected async Task GetArtworkBykeyword() 
    {
        _matchingArtworkIds = await _artworkService.GetArtworkIdsByKeyword(_currentKeyword ?? string.Empty);
        _currentArtworkIndex = 0;
    }


}
