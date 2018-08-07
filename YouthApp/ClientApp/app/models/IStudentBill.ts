export interface IStudentBill {
    term: string;
    uniqueID: string;
    name: string;
    bill: Array<{ item: string, amount: number }>;
}