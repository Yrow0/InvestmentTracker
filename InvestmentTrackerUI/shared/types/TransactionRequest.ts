export class TransactionRequest {
    typeId? : string
    categoryId? : string
    amount: number
    description? : string
    date? : Date

    constructor(data: Partial<TransactionRequest>) {
    this.typeId = data.typeId
    this.categoryId = data.categoryId
    this.amount = data.amount ?? 0
    this.description = data.description
    this.date = data.date
    
  }

  toJson(): Record<string, any> {
    return {
      typeId: this.typeId,
      categoryId: this.categoryId,
      amount: this.amount,
      description: this.description,
      date: this.date,
    }
  }

}