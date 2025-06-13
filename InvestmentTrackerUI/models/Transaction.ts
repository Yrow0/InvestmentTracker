export class Transaction {
    typeId? : string
    categoryId? : string
    amount: number
    description? : string

    constructor(data: Partial<Transaction>) {
    this.typeId = data.typeId
    this.categoryId = data.categoryId
    this.amount = data.amount ?? 0
    this.description = data.description
  }

  toJson(): Record<string, any> {
    return {
      typeId: this.typeId,
      categoryId: this.categoryId,
      amount: this.amount,
      description: this.description,
    }
  }

}