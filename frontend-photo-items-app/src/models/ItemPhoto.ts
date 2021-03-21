import Item from "./Item";
import ItemPhotoPropertySet from "./ItemPhotoPropertySet";
import Type from "./Type";

export default class ItemPhoto {

  public id: number = 0;
  public itemId: number = 0;
  public typeId: number = 0;
  public fileName: string = "";
  public position: number = 0;
  public alt: string = "";
  public createdAt: Date = new Date();
  public modifiedAt: Date = new Date();
  public isActive: boolean = true;

  //Navigations
  public itemNavigation: Item = new Item();
  public typeNavigation: Type = new Type();
  public itemPhotoPropertySet: ItemPhotoPropertySet[] = [];

  constructor(itemPhoto?: Partial<ItemPhoto>) {
    Object.assign(this, itemPhoto);
  }

}