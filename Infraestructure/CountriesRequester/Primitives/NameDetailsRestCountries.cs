using System.Text.Json.Serialization;



namespace Infraestructure.CountriesRequester.Primitives;


/// <summary>
/// La clase para los detalles del nombre.<para/><para/>
/// 
/// Se utiliza esta clase porque a la hora de covertir el fichero json al objeto <see cref="CountryRestCountries"/>, se tiene
/// que convertir a un objeto, ya que el parámetro name del fichero json es complejo.
/// </summary>
public class NameDetailsRestCountries
{
    [JsonPropertyName("common")]
    public string Common { get; set; }

    [JsonPropertyName("official")]
    public string Official { get; set; }
}
