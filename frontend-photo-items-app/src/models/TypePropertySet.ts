import Property from "./Property";
import Type from "./Type";

export default class TypePropertySet {

  public id: number = 0;
  public mediaTypeId: number = 0;
  public propertyId: number = 0;
  public value: string = "";

  //Navigations
  public mediaTypeNavigation: Type = new Type();
  public propertyNavigation: Property = new Property();

  constructor(typePropertySet?: Partial<TypePropertySet>) {
    Object.assign(this, typePropertySet);
  }

}