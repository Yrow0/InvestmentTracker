import type { Category } from "./Category"
import type { Type } from "./Type"

export class Transaction {
    id? : string
    typeId? : number
    categoryId? : number
    amount: number
    description? : string
    category? : Category
    type? : Type
    date? : Date

    constructor(data: Partial<Transaction>) {
    this.id = data.id
    this.typeId = data.typeId
    this.categoryId = data.categoryId
    this.amount = data.amount ?? 0
    this.description = data.description
    this.category = data.category
    this.type = data.type
    this.date = data.date
  }

}