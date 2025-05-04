using Microsoft.AspNetCore.Components;
using Museum.API;
using Museum.API.Models;

namespace Museum.UI.Components;

public partial class ArtworkDetails
{
    [Inject]
    public IArtworkService _artworkService { get; set; } = default!; 

    [Parameter]
    public string? Id { get; set; }

    public ArtworkDetailsModel? _artworkDetailsModel { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        if (Id is not null) 
        {
            _artworkDetailsModel = await _artworkService.GetArtworkById(Id);
        }
    }
    protected override async Task OnParametersSetAsync()
    {
        if (Id is not null)
            _artworkDetailsModel = await _artworkService.GetArtworkById(Id);
    }
}
