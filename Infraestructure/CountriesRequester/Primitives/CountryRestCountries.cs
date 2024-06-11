using System.Text.Json.Serialization;



namespace Infraestructure.CountriesRequester.Primitives;


/// <summary>
/// La clase que se utiliza para convertir el fichero json a un objeto.<para/><para/>
/// 
/// Este tipo lo utilizará solo el solicitante de ficheros, <seealso cref="CountriesRequesterRestCountries"/>, ya que este su
/// estructura viene condicionada por el formato del fichero json recibido desde el API RestCountries.
/// </summary>
public class CountryRestCountries
{
    //Se utilizan los atributos para indicar qué parámetro del fichero json corresponde con la propiedad de la clase.
    [JsonPropertyName("name")]
    public NameDetailsRestCountries NameDetails { get; set; }

    [JsonPropertyName("population")]
    public int Population { get; set; }
}
