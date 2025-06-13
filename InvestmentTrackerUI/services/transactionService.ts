import { Transaction } from "~/models/Transaction"

export async function AddTransaction(transaction: Transaction) {
  const response = await $fetch.raw('https://localhost:7003/api/transactions', {
    method: 'POST',
    body: transaction.toJson(),
  });

  return false;
}