using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Core.Models;
using AssetTracker.Core.Models.Interfaces.BaseInterface;

namespace AssetTracker.Core.DAL.BaseDAL
{
    public class BaseRepository<T>:IRepository<T> where T:class
    {
        protected DbContext db { get; set; }

        public DbSet<T> Table {
            get { return db.Set<T>(); }
        }

        public BaseRepository(DbContext db)
        {
           this.db = db;
        }

        public bool Insert(T entity)
        {
            try
            {
                Table.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public bool Edit(T entity)
        {
            try
            {
                Table.AddOrUpdate(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public bool Delete(T entity)
        {
            try {
                Table.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
                return true;
            } catch (Exception) {
               throw new Exception();
            }
        }

        public T GetFirstOrDefaultBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return includes
                .Aggregate(
                    Table.AsQueryable(),
                    (current, include) => current.Include(include),
                    c=>c.FirstOrDefault(predicate)
                );
        }

        public ICollection<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            return includes
                .Aggregate(
                   Table.AsQueryable(),
                    (current, include) => current.Include(include)
                ).ToList();
        }

        public ICollection<T> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return includes
               .Aggregate(
                   Table.AsQueryable(),
                   (current, include) => current.Include(include),
                  c => c.Where(predicate)
               ).ToList();
        }


    }
}
