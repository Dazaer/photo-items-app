import PropertyType from "./PropertyType";

export default class ShapeType extends PropertyType<ShapeType> {
	public id: number = 0;
	public description: string = "";

	constructor(shapeType?: Partial<ShapeType>) {
		super();
    Object.assign(this, shapeType);
	}

	public static getShapeTypes() {
		const shapeTypeList: ShapeType[] = [];

    shapeTypeList.push(new ShapeType({id: 1, description: "Cushion"}));
    shapeTypeList.push(new ShapeType({id: 2, description: "Round"}));

		return shapeTypeList;
	}
}
