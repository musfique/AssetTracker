using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker.Core.Models.Interfaces.BaseInterface
{
    public interface IManager<T> where T : class
    {
        bool Insert(T entity);
        bool Edit(T entity);
        bool Delete(int id);
        T GetById(int id);
        ICollection<T> GetAll();
        
    }
}
