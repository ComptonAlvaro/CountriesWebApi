namespace Shared.Infraestructure.CountryRequester.Exceptions;



/// <summary>
/// Excepción que se produce cuando no se tiene acceso al recurso, que podrá ser porque el servicio API no está disponible en caso
/// de ser un servicio API, porque el fichero no está accesible de tratarse de un finchero local... etc.
/// </summary>
public class ResourceNotAvailableException : Exception
{
    public ResourceNotAvailableException()
    {
    }

    public ResourceNotAvailableException(string message)
        : base(message)
    {
    }

    public ResourceNotAvailableException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
