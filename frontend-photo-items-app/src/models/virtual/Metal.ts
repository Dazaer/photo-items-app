import Property from "../Property";

export default class Metal extends Property {

  public id: number = 1;
  public name: string = "Metal";

  constructor(metal?: Partial<Metal>) {
    super(metal)
  }

  public static getNullSelectedMetal() {
    return new Metal({name: "All"});
  }
}