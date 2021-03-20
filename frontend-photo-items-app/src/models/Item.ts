export default class Item {

  public id: number = 0;
  public name: string = "";

  constructor(item?: Partial<Item>) {
    Object.assign(this, item);
  }

  public static getNullSelectedItem() {
    return new Item({name: "All"});
  }
}