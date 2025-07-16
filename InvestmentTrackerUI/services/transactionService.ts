import type { Transaction } from "~/shared/types/Transaction";
import { TransactionRequest } from "~/shared/types/TransactionRequest"
import type { TransactionsByMonth } from "~/shared/types/TransactionsByMonth";

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

export async function GetTransactionsByMonth()
{
  const response = await $fetch.raw('https://localhost:7003/api/transactions/monthly', {
    method: 'get',
  });
  console.log(response._data);
  return response._data as TransactionsByMonth[];
}

export async function GetAmountOfTransactionsByCategory()
{
  const response = await $fetch.raw('https://localhost:7003/api/transactions/amountbycategory', {
    method: 'get',
  });
  console.log("amountbycategory")
  console.log(response._data);
  return response._data as {[id: number] : number};
}