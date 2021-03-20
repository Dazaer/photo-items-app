using System;
using System.Collections.Generic;

#nullable disable

namespace BackendPhotoItemsApp.Models.Db
{
    public partial class Type
    {
        public Type()
        {
            ItemPhotos = new HashSet<ItemPhoto>();
            TypePropertySets = new HashSet<TypePropertySet>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ItemPhoto> ItemPhotos { get; set; }
        public virtual ICollection<TypePropertySet> TypePropertySets { get; set; }
    }
}
