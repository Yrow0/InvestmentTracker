import type { Transaction } from "~/models/Transaction";
import { TransactionRequest } from "~/models/TransactionRequest"

export async function AddTransaction(transaction: TransactionRequest) {
  const response = await $fetch.raw('https://localhost:7003/api/transactions', {
    method: 'POST',
    body: transaction.toJson(),
  });

  return response.status >= 200 && response.status < 300;
}

export async function GetTransactions() {
  const response = await $fetch.raw('https://localhost:7003/api/transactions', {
    method: 'get',
  });
  console.log(response._data);
  return response._data as Transaction[];
}