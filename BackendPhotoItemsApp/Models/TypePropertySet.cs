using System;
using System.Collections.Generic;

#nullable disable

namespace BackendPhotoItemsApp.Models
{
    public partial class TypePropertySet
    {
        public int Id { get; set; }
        public int MediaTypeId { get; set; }
        public int PropertyId { get; set; }

        public virtual Type MediaType { get; set; }
        public virtual Property Property { get; set; }
    }
}
