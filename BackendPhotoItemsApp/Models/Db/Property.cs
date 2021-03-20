using System;
using System.Collections.Generic;

#nullable disable

namespace BackendPhotoItemsApp.Models.Db
{
    public partial class Property
    {
        public Property()
        {
            ItemPhotoPropertySets = new HashSet<ItemPhotoPropertySet>();
            TypePropertySets = new HashSet<TypePropertySet>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ItemPhotoPropertySet> ItemPhotoPropertySets { get; set; }
        public virtual ICollection<TypePropertySet> TypePropertySets { get; set; }
    }
}
