using Museum.API.Models;
using Newtonsoft.Json;

namespace Museum.API;

public class ArtworkService : IArtworkService
{

    private readonly HttpClient client = new HttpClient();

    public async Task<List<string>?> GetArtworkIdsByDepartment(long departmentId) 
    {
        using HttpResponseMessage response = await client.GetAsync($"https://collectionapi.metmuseum.org/public/collection/v1/objects?departmentIds={departmentId}");
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();

        var artworksModel = JsonConvert.DeserializeObject<ArtworksModel>(responseBody);

        return artworksModel?.ObjectIDs?.ToList().ConvertAll<string>(x => x.ToString());
    }

    public async Task<List<string>?> GetArtworkIdsByKeyword(string? keyword) 
    {
        using HttpResponseMessage response = 
            await client.GetAsync($"        https://collectionapi.metmuseum.org/public/collection/v1/search?q={keyword}");
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();

        var artworksModel = JsonConvert.DeserializeObject<ArtworksModel>(responseBody);

        return artworksModel?.ObjectIDs?.ToList().ConvertAll<string>(x => x.ToString());
    }



    public async Task<ArtworkDetailsModel?> GetArtworkById(string id) 
    {
        using HttpResponseMessage response = await client.GetAsync($"https://collectionapi.metmuseum.org/public/collection/v1/objects/{id}");
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();

        var artworksModel = JsonConvert.DeserializeObject<ArtworkDetailsModel>(responseBody);

        return artworksModel;
    }
}
