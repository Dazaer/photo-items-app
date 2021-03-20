using BackendPhotoItemsApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendPhotoItemsApp.Dtos {
    public class ItemPostDto {

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public virtual ICollection<ItemPhoto> ItemPhotos { get; set; }
    }
}
