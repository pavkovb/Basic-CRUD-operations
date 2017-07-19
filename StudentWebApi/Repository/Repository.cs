using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace StudentWebApi.Repository
{
    public class Repository<TEntity> where TEntity : class
    {
        #region Fields

        protected readonly DbContext Context;

        #endregion

        #region Constructor

        public Repository(DbContext context)
        {
            Context = context;
        }

        #endregion

        #region Methods

        public IEnumerable<TEntity> GetList()
        {
            return Context.Set<TEntity>().ToList();
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public TEntity FindById(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        #endregion





        //public TEntity GetByKey(int id)
        //{
        //    GetList().FirstOrDefault(x => x.Id == id);
        //}
    }
}