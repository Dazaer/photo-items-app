import PropertyType from "./virtual/PropertyType";

export default class Property {

  public id: number = 0;
  public name: string = "";

  constructor(item?: Partial<Property>) {
    Object.assign(this, item);
  }

  public static getNullSelectedPropertyType<TEntity>() {
    return new PropertyType<TEntity>({description: "All"});
  }
}