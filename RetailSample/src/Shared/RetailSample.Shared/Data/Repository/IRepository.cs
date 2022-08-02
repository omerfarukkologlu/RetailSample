using RetailSample.Shared.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RetailSample.Shared.Data.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        public void Add(TEntity entity);
        public void Update(TEntity entity);
        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null);
        public void Delete(TEntity entity);
        public TEntity GetById(int id);
    }
}
