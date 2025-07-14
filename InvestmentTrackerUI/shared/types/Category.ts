export class Category {
    categoryId? : string
    name? : string

    constructor(data: Partial<Category>) {
    this.categoryId = data.categoryId
    this.name = data.name
  }

  toJson(): Record<string, any> {
    return {
      categoryId: this.categoryId,
      name: this.name,
    }
  }

}