using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace Toolkit.Data;

public class Repository<TEntity, TKey, TContext> : IRepository<TEntity, TKey>
    where TContext:DbContext
    where TEntity : class
{

    readonly TContext _context;

    public Repository(TContext context)
    {
        _context = context;
    }

    public void Delete(TKey key)
    {
        var entity = _context.Set<TEntity>().Find(key);
        _context.Set<TEntity>().Remove(entity);
    }

    public TEntity Get(TKey key)
    {
       return _context.Set<TEntity>().Find(key);
    }

    public TEntity Get(Expression<Func<TEntity, bool>> expression)
    {
        return _context.Set<TEntity>().FirstOrDefault(expression);
    }

    public void Insert(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
    }


    public void LoadCollection<TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> collectionProperty)
       where TProperty : class
    {
        var collection = _context.Entry(entity).Collection(collectionProperty);
        if (!collection.IsLoaded)
            collection.Load();
    }
    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
