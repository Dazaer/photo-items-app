using System;
using System.Collections.Generic;

#nullable disable

namespace BackendPhotoItemsApp.Models.Db
{
    public partial class Item
    {
        public Item()
        {
            ItemPhotos = new HashSet<ItemPhoto>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ItemPhoto> ItemPhotos { get; set; }
    }
}
