namespace Shared.Infraestructure.Repositories.Commands;



/// <summary>
/// La definición general del repositorio de comandos que tiene las acciones básicas que todo repositorio debe implementar.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IRepository<TEntity> : IDisposable where TEntity : class
{
    /// <summary>
    /// Agrega una entidad al repositorio en estado sin modificar para empezar a realizar el seguimiento. Al ser en
    /// estado sin modificar, cuando se persistan los cambios no hará nada con la entidad, ni se guardará en la base de datos, ni
    /// se actualizará ni se borrará. Tan solo se agrega al contexto para hacer seguimiento de sus modificaciones.
    /// </summary>
    /// <param name="entity"></param>
    void Attach(TEntity entity);

    /// <summary>
    /// Agrega varios entidades al repositorio en estado sin modificar para empezar a realizar el seguimiento. Al ser en
    /// estado sin modificar, cuando se persistan los cambios no hará nada con la entidad, ni se guardará en la base de datos, ni
    /// se actualizará ni se borrará. Tan solo se agrega al contexto para hacer seguimiento de sus modificaciones.
    /// </summary>
    /// <param name="entity"></param>
    void AttachRange(IEnumerable<TEntity> entities);


    /// <summary>
    /// Agrega una entidad al repositorio en estado agregada para empezar a realizar el seguimiento. Al ser en
    /// estado agregado, cuando se persistan los cambios se agregará el registro en la base de datos.
    /// </summary>
    /// <param name="entity"></param>
    void Add(TEntity entity);

    /// <summary>
    /// Agrega varios entidades al repositorio en estado agregada para empezar a realizar el seguimiento. Al ser en
    /// estado agregado, cuando se persistan los cambios se agregará el registro en la base de datos.
    /// </summary>
    /// <param name="entity"></param>
    void AddRange(IEnumerable<TEntity> entities);


    /// <summary>
    /// Agrega una entidad al repositorio en estado borrada para empezar a realizar el seguimiento. Al ser en
    /// estado borrado, cuando se persistan los cambios se borrará el registro en la base de datos.
    /// </summary>
    /// <param name="entity"></param>
    void Remove(TEntity entity);

    /// <summary>
    /// Agrega varias entidades al repositorio en estado borrada para empezar a realizar el seguimiento. Al ser en
    /// estado borrado, cuando se persistan los cambios se borrará el registro en la base de datos.
    /// </summary>
    /// <param name="entity"></param>
    void RemoveRange(IEnumerable<TEntity> entities);
}
