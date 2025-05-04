using Newtonsoft.Json;

namespace Museum.API.Models;

public class ArtworksModel
{
    
    [JsonProperty("total")]
    public long Total { get; set; }
    
    [JsonProperty("objectIDs")]
    public long[]?  ObjectIDs { get; set; }
    
}

