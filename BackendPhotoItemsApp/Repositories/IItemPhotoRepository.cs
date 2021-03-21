using BackendPhotoItemsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendPhotoItemsApp.Repositories {
    public interface IItemPhotoRepository : IRepository<ItemPhoto> {
        IQueryable<ItemPhoto> GetAllByType(int typeId);
        IQueryable<ItemPhoto> GetAllByItem(int itemId);
    }
}
