import type { Category } from "./Category"
import type { Transaction } from "./Transaction"
import type { Type } from "./Type"

export class TransactionsByMonth {
    month? : string
    public transactions? : Transaction[]

    constructor(data: Partial<TransactionsByMonth>) {
    this.month = data.month
    this.transactions = data.transactions
    
  }

}