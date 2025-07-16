import { Type } from "~/shared/types/Type"

export async function GetTypes() {
  const response = await $fetch.raw('https://localhost:7003/api/transactiontypes', {
    method: 'get',
  });
  console.log(response._data);
  return response._data as Type[];
}