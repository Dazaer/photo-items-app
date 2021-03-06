using BackendPhotoItemsApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendPhotoItemsApp.Repositories {
    public class ItemPhotoRepository : Repository<ItemPhoto>, IItemPhotoRepository {
        public ItemPhotoRepository(AppDbContext context) : base(context) {
        }

        public IQueryable<ItemPhoto> GetAllWithProperties() {
            return _context.ItemPhotos
                .Include(itemPhoto => itemPhoto.ItemPhotoPropertySets);
        }
        public IQueryable<ItemPhoto> GetAllByItem(int itemId) {
            return _context.ItemPhotos
                .Include(itemPhoto => itemPhoto.Item)
                .Where(itemPhoto => itemPhoto.ItemId == itemId);
        }

        public IQueryable<ItemPhoto> GetAllByType(int typeId) {
            return _context.ItemPhotos
                .Include(itemPhoto => itemPhoto.Type)
                .Where(itemPhoto => itemPhoto.TypeId == typeId);
        }

        public void RemoveWithPropertySet(ItemPhoto itemPhoto) {
            IQueryable<ItemPhotoPropertySet> set = _context.ItemPhotoPropertySets.Where(set => set.ItemPhotoId == itemPhoto.Id);
            _context.RemoveRange(set);
            _context.Remove(itemPhoto);
        }
    }
}
