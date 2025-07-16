export class Type {
    typeId? : string
    name? : string

    constructor(data: Partial<Type>) {
    this.typeId = data.typeId
    this.name = data.name
  }

  toJson(): Record<string, any> {
    return {
      typeId: this.typeId,
      name: this.name,
    }
  }

}