import { eTerms } from "./eTerms";

export interface IClassBills {
    classBillsID: number;
    billItemsID: number;
    billItem: string;
    classesID: number;
    amount: number;
    terms: eTerms;
    year: string;
    datePrepared: Date
    concurrency: string;
}