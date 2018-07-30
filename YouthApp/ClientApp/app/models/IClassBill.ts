import { eTerms } from "./eTerms";

export interface IClassBills {
    classBillsID: number;
    billItemsID: number;
    billItem: string;
    classesID: number;
    amount: number;
    termsID: number;
    datePrepared: Date
    concurrency: string;
}