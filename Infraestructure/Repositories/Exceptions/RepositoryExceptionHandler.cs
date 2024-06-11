using Shared.Infraestructure.Repositories.Exceptions;



namespace Infraestructure.Repositories.Exceptions;



internal static class RepositoryExceptionHandler
{
    public static Exception GetException(Exception paramException)
    {
        Microsoft.Data.Sqlite.SqliteException? exception = paramException.GetBaseException() as Microsoft.Data.Sqlite.SqliteException;
        if(exception is Microsoft.Data.Sqlite.SqliteException)
        {
            if(exception.SqliteErrorCode == 1)
            {
                throw new DataBaseNotAvailableException("La ruta de la base de datos no es correcta.", exception);
            }
        }



        throw new UnknownRepositoryException("Error desconido.", paramException);
    }
}
