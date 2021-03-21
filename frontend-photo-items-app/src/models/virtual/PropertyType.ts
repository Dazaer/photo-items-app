
export default class PropertyType<TEntity> {

  public id: number = 0;
  public description: string = "";

  constructor(propertyType?: Partial<PropertyType<TEntity>>) {
    Object.assign(this, propertyType);
  }

}