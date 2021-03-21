import Property from "../Property";

export default class Shape extends Property {

  public id: number = 2;
  public name: string = "Shape";

  constructor(shape?: Partial<Shape>) {
    super(shape);
  }
}