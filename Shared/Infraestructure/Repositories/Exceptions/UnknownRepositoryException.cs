namespace Shared.Infraestructure.Repositories.Exceptions;



/// <summary>
/// Una excepción genérica cuando no se ha podido determinar la excepción.
/// </summary>
public class UnknownRepositoryException : Exception
{
    public UnknownRepositoryException()
    {
    }

    public UnknownRepositoryException(string message)
        : base(message)
    {
    }

    public UnknownRepositoryException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
