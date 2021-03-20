using System.Collections.Generic;
using System.Linq;

namespace BackendPhotoItemsApp.Repositories {

    public interface IRepository<TEntity> where TEntity : class, new() {
        TEntity Get(int id);
        IQueryable<TEntity> GetAll();

        void Add(TEntity entity);

        //void Update(TEntity entity);

        void Remove(TEntity entity);

        bool SaveChanges();
    }
}
