import Property from "../Property";
import MetalType from "./MetalType";

export default class Metal extends Property {

  public id: number = 1;
  public name: string = "Metal";

  //public values: MetalType[] = [];

  constructor(metal?: Partial<Metal>) {
    super();
    Object.assign(this, metal);
  }

}