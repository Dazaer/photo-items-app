using BackendPhotoItemsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendPhotoItemsApp.Repositories {
    public class ItemPhotoPropertySetRepository : Repository<ItemPhotoPropertySet>, IItemPhotoPropertySetRepository {
        public ItemPhotoPropertySetRepository(AppDbContext context) : base(context) {
        }


    }
}
