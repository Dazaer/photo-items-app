using BackendPhotoItemsApp.Models;
using System;
using System.Collections.Generic;

namespace BackendPhotoItemsApp.Dtos {
    public class ItemPhotoDto {

        public int Id { get; set; }
        public int? ItemId { get; set; }
        public int TypeId { get; set; }
        public string FileName { get; set; }

        //public int? Position { get; set; }
        //public string Alt { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public DateTime? ModifiedAt { get; set; }
        //public bool? IsActive { get; set; }

        //public virtual Item Item { get; set; }
        //public virtual Models.Type Type { get; set; }
        //public virtual ICollection<ItemPhotoPropertySet> ItemPhotoPropertySets { get; set; }
    }
}
