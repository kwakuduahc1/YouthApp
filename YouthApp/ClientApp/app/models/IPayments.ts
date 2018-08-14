import { IStudents } from "./IStudents";

export interface IPayments {
    datePaid: Date;
    receiver: string;
    amount: number;
    studentsID: number;
    paymentsID: string;
    concurrency: string;
    students: IStudents;
    gcr: string;
    transactionsID: number;
}