using BackendPhotoItemsApp.Models;

namespace BackendPhotoItemsApp.Dtos {
    public class ItemDto {

        public int Id { get; set; }

        public string Name { get; set; }
        //public virtual ICollection<ItemPhoto> ItemPhotos { get; set; }
    }
}
