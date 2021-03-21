import PropertyType from "./PropertyType";

export default class MetalType extends PropertyType<MetalType> {
	public id: number = 0;
	public description: string = "";

	constructor(metalType?: Partial<MetalType>) {
		super();
    Object.assign(this, metalType);
	}

	public static getMetalTypes() {
		const metalTypesList: MetalType[] = [];

		metalTypesList.push(new MetalType({ id: 1, description: "Rose gold" }));
		metalTypesList.push(new MetalType({ id: 2, description: "Yellow gold" }));
		metalTypesList.push(new MetalType({ id: 3, description: "Platinum" }));

		return metalTypesList;
	}
}
