namespace Domain.Countries.Services;




/// <summary>
/// El servicio que se encarga de gestionar una lista con todos los países.
/// </summary>
public static class AddUpdateAndDeleteCountriesService
{
    /// <summary>
    /// Actualiza los paises que existen actulamente con el valor actualizado que ser recibe. Si un país se tiene actualmente y no
    /// se recibe, se considera que ya no existe y se agregará a la lista de países que se tinene que borrar. Si un país no se
    /// tiene actualmente y se recibe, se considera un país nuevo que se tendrá que agregar.
    /// </summary>
    /// <param name="paramActualCoutries">La lista actual de países que se tienen.</param>
    /// <param name="paramNewCountries">La lista de países que se tienen que tener al final.</param>
    /// <returns>Una tupla con dos elementos. El primero de ellos los países nuevos que se tienen que agregar y el segundo elemento
    /// con los países que se tienen que borrar. No se devuelven los países actualizados porque se actualiza el país actual con
    /// la información nueva.</returns>
    public static (List<Country> NewContries, List<Country> DeletedCountries) AddUpdateAndDeleteCountries(IList<Country> paramActualCoutries, IEnumerable<Country> paramNewCountries)
    {
        //Un diccionario con los paises actuales, para que la búsqueda sea más rápida al determinar si se tiene que actualizar
        //o agregar el país con los datos nuevos.
        //No se espera que las referncias de los países sean las mismas, porque unas entidades procederán de la base de datos local
        //y las otras del fichero json del API externo, por eso se utiliza un diccionario.
        Dictionary<string, Country> actualCountriesDictionary = paramActualCoutries.ToDictionary(x => x.Name, y => y);



        //Se actualizan los países con la información nueva y se agregan los países nuevos.
        List<Country> newCountries = [];

        foreach(Country iteratorNewCountry in paramNewCountries)
        {
            Country? actualCountry = actualCountriesDictionary.GetValueOrDefault(iteratorNewCountry.Name);

            if(actualCountry == null)
            {
                newCountries.Add(iteratorNewCountry);
            }
            else
            {
                actualCountry.SetPopulation(iteratorNewCountry.Population);
            }
        }


        //Se obtienen los países que se tienen que borrar.
        HashSet<string> nameNewCountries = new HashSet<string>(paramNewCountries.Select(x => x.Name));
        List<Country> deletedCountries = actualCountriesDictionary.Where(x => nameNewCountries.Contains(x.Key) == false).Select(x => x.Value).ToList();



        return (newCountries, deletedCountries);
    }
}
