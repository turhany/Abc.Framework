using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Abc.Core.Entities;

namespace Abc.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()  //class > reference type, new olabilirim bir obje
    {
        T Get(Expression<Func<T, bool>> filter);

        List<T> GetList(Expression<Func<T, bool>> filter = null);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
