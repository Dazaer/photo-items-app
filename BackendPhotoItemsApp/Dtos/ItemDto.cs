using BackendPhotoItemsApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendPhotoItemsApp.Dtos {
    public class ItemDto {

        public int Id { get; set; }

        public string Name { get; set; }
        //public virtual ICollection<ItemPhoto> ItemPhotos { get; set; }
    }
}
