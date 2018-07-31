export interface IIndividualBills {
    individualBillsID: number;
    studentsID: number;
    amount: number;
    termsID: number;
    description: string;
    isPaid: boolean;
    dateBilled: Date;
    concurrency: string;
}