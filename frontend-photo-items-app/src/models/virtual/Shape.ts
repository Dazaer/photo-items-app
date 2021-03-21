import Property from "../Property";

export default class Shape extends Property {
	public id: number = 2;
	public name: string = "Shape";

	/*   
  public values: object[] = [
    {id: 1, description: "Cushion"},
    {id: 2, description: "Round"},
  ]; 
  */

	constructor(shape?: Partial<Shape>) {
		super(shape);
	}
}
