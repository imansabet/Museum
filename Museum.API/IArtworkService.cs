
using Museum.API.Models;

namespace Museum.API
{
    public interface IArtworkService
    {
        Task<List<string>?> GetArtworkIdsByDepartment(long departmentId);

        Task<List<string>?> GetArtworkIdsByKeyword(string? keyword);
        Task<ArtworkDetailsModel?> GetArtworkById(string id);

    }
}