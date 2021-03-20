using BackendPhotoItemsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendPhotoItemsApp.Repositories {
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new() {
        protected readonly AppDbContext _context;

        public Repository(AppDbContext context) {
            _context = context;
        }

        public TEntity Get(int id) {
            return _context.Find<TEntity>(id);
        }

        public IQueryable<TEntity> GetAll() {
            return _context.Set<TEntity>();
        }

        public void Add(TEntity entity) {
            if (entity == null) {
                throw new ArgumentNullException($"{nameof(Add)} entity must not be null");
            }

            _context.Add(entity);
        }

        /*
        public TEntity Update(TEntity entity) {
            throw new NotImplementedException();
        }
        */

        public void Remove(TEntity entity) {
            //TEntity dbEntity = _context.Find<TEntity>(entity);

            if (entity == null) {
                throw new ArgumentNullException($"{nameof(Remove)} entity must not be null");
            }

            _context.Remove(entity);
        }

        public bool SaveChanges() {
            return (_context.SaveChanges() >= 0);
        }
    }
}
