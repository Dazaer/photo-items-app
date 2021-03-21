using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendPhotoItemsApp.Dtos {
    public class TypeDto {
        public int Id { get; set; }
        public string Name { get; set; }

        //public virtual ICollection<ItemPhoto> ItemPhotos { get; set; }
        //public virtual ICollection<TypePropertySet> TypePropertySets { get; set; }
    }
}
