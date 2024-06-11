using System.Text.Json.Serialization;



namespace Shared.Primitives;



public class CountryDTO
{
    public CountryDTO() { }

    public CountryDTO(string paramName, int paramPopulation)
    {
        Name = paramName;
        Population = paramPopulation;
    }




    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("population")]
    public int Population { get; set; }
}
