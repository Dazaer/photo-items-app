using BackendPhotoItemsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendPhotoItemsApp.Dtos {
    public class ItemPhotoPropertySetDto {
        public int Id { get; set; }
        public int ItemPhotoId { get; set; }
        public int PropertyId { get; set; }
        public string Value { get; set; }

        //public virtual ItemPhoto ItemPhoto { get; set; }
        //public virtual Property Property { get; set; }
    }
}
