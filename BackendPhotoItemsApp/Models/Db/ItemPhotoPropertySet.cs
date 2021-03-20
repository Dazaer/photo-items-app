using System;
using System.Collections.Generic;

#nullable disable

namespace BackendPhotoItemsApp.Models.Db
{
    public partial class ItemPhotoPropertySet
    {
        public int Id { get; set; }
        public int ItemPhotoId { get; set; }
        public int PropertyId { get; set; }
        public string Value { get; set; }

        public virtual ItemPhoto ItemPhoto { get; set; }
        public virtual Property Property { get; set; }
    }
}
