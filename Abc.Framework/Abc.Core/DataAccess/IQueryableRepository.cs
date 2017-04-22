using System.Linq;
using Abc.Core.Entities;

namespace Abc.Core.DataAccess
{
    public interface IQueryableRepository<T> where T : class, IEntity, new()
    {
        IQueryable<T> Table { get; }
    }
}
