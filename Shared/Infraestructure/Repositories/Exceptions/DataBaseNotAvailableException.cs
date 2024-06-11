namespace Shared.Infraestructure.Repositories.Exceptions;



/// <summary>
/// Excepción que se produce cuando la base de datos no es accesible, por ejemplo cuando la ruta local no es correcta o si es una
/// base de datos remota, por un fallo de red.
/// </summary>
public class DataBaseNotAvailableException : Exception
{
    public DataBaseNotAvailableException()
    {
    }

    public DataBaseNotAvailableException(string message)
        : base(message)
    {
    }

    public DataBaseNotAvailableException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
