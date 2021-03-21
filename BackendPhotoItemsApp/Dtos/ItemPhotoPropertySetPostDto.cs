using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendPhotoItemsApp.Dtos {
    public class ItemPhotoPropertySetPostDto {

        [Required]
        public int Id { get; set; }

        [Required]
        public int ItemPhotoId { get; set; }

        [Required]
        public int PropertyId { get; set; }

        [MaxLength(50)]
        public string Value { get; set; }

        //public virtual ItemPhoto ItemPhoto { get; set; }
        //public virtual Property Property { get; set; }
    }
}
