import { Category } from "~/models/Category"


export async function GetCategories() {
  const response = await $fetch.raw('https://localhost:7003/api/categories', {
    method: 'get',
  });
  console.log(response._data);
  return response._data as Category[];
}