export default class Property {

  public id: number = 0;
  public name: string = "";

  constructor(item?: Partial<Property>) {
    Object.assign(this, item);
  }

  public static getNullSelectedProperty() {
    return new Property({name: "All"});
  }
}