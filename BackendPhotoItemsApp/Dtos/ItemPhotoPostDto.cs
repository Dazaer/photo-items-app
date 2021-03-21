using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendPhotoItemsApp.Dtos {
    public class ItemPhotoPostDto {
        public int? ItemId { get; set; }

        [Required]
        public int TypeId { get; set; }

        [MaxLength(50)]
        public string FileName { get; set; }

        public int? Position { get; set; }

        [MaxLength(500)]
        public string Alt { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        [Required]
        public bool? IsActive { get; set; }
        //public virtual Item Item { get; set; }
        //public virtual Models.Type Type { get; set; }
        //public virtual ICollection<ItemPhotoPropertySet> ItemPhotoPropertySets { get; set; }
    }
}
