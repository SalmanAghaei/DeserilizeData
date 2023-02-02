using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Toolkit.Data;

public interface IRepository<TEntity, Tkey>
{
    void Insert(TEntity entity);
    void Delete(Tkey entity);
    TEntity Get(Tkey key);
    TEntity Get(Expression<Func<TEntity, bool>> expression);
    void SaveChanges();
    void LoadCollection<TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> collectionProperty)
       where TProperty : class;
}
