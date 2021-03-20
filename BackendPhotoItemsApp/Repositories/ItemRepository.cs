using BackendPhotoItemsApp.Models;
using BackendPhotoItemsApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendPhotoItemsApp.Repositories {
    public class ItemRepository : Repository<Item> {
        public ItemRepository(AppDbContext context) : base(context) {
        }
    }
}
