using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Shared.Infraestructure.Repositories.Commands;



namespace Infraestructure.Repositories.Commands;


public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly DbContext _dbContext;

    public Repository(DbContext paramDbContext)
    {
        _dbContext = paramDbContext;
    }





    public void Attach(TEntity entity)
    {
        _dbContext.Attach(entity);
    }

    public void AttachRange(IEnumerable<TEntity> entities)
    {
        _dbContext.Set<TEntity>().AttachRange(entities);
    }

    public void Add(TEntity entity)
    {
        _dbContext.Set<TEntity>().Add(entity);
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
        _dbContext.Set<TEntity>().AddRange(entities);
    }



    public void Remove(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        _dbContext.Set<TEntity>().RemoveRange(entities);
    }





    #region Dispose
    //Aquí se implementa el dispose, que según la documentación de Microsoft, es recomendable implementarlo. La implementación
    //es de la documentación de Microsoft.
    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    #endregion Dispose
}
