import { IStudents } from "./IStudents";

export interface IPayments {
    datePaid: Date;
    receiver: string;
    amount: number;
    studentsID: string;
    paymentsID: string;
    concurrency: string;
    students: IStudents;
}