export default class Type {

  public id: number = 0;
  public name: string = "";

  constructor(type?: Partial<Type>) {
    Object.assign(this, type);
  }

}