import { elements } from "chart.js";
import { TransactionsByMonth } from "../types/TransactionsByMonth";

export function GetAllPresentMonth(transaction: TransactionsByMonth[]) : string[]
{
    const months:string[] = [];
    transaction.forEach((element) => months.push(element.month));
    console.log("months");
    console.log(months);
    return months;
}