using System;
using System.Collections.Generic;

#nullable disable

namespace BackendPhotoItemsApp.Models
{
    public partial class ItemPhoto
    {
        public ItemPhoto()
        {
            ItemPhotoPropertySets = new HashSet<ItemPhotoPropertySet>();
        }

        public int Id { get; set; }
        public int? ItemId { get; set; }
        public int TypeId { get; set; }
        public string FileName { get; set; }
        public int? Position { get; set; }
        public string Alt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool? IsActive { get; set; }

        public virtual Item Item { get; set; }
        public virtual Type Type { get; set; }
        public virtual ICollection<ItemPhotoPropertySet> ItemPhotoPropertySets { get; set; }
    }
}
