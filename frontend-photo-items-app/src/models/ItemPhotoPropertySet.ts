import ItemPhoto from "./ItemPhoto";
import Property from "./Property";

export default class ItemPhotoPropertySet {

  public id: number = 0;
  public itemPhotoId: number = 0;
  public propertyId: number = 0;
  public value: string = "";

  //Navigations
  public itemPhotoNavigation: ItemPhoto = new ItemPhoto();
  public propertyNavigation: Property = new Property();

  constructor(itemPhotoPropertySet?: Partial<ItemPhotoPropertySet>) {
    Object.assign(this, itemPhotoPropertySet);
  }

}