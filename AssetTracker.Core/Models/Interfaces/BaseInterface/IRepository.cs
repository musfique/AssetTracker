using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker.Core.Models.Interfaces.BaseInterface
{
    public interface IRepository<T> where T:class
    {
        bool Insert(T entity);
        bool Edit(T entity);
        bool Delete(T entity);
        T GetFirstOrDefaultBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        ICollection<T> GetAll(params Expression<Func<T, object>>[] includes);
        ICollection<T> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
    }
}
