import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IHttpMethods } from '../IHttpMethods';
import { Observable } from 'rxjs/Observable';
import { IStudents } from '../../models/IStudents';
import { IIndividualBills } from '../../models/IIndBill';
import { not } from '@angular/compiler/src/output/output_ast';
import { IPayments } from '../../models/IPayments';

@Injectable()
export class StudentPaymentsHttpService  {


    find(id: string): Observable<IPayments> | null {
        throw new Error("Method not implemented.");
    }
    list(id:number): Observable<IPayments[]> {
        return this.http.get<IPayments[]>(`/Payments/Student/${id}`);
    }
    add(item: IPayments): Observable<IPayments> {
        return this.http.post<IPayments>('/Payments/Create', item);
    }
    edit(item: IPayments): Observable<IPayments> {
        throw new Error("Method not implemented.");
    }
    delete(item: IPayments): Observable<void> {
        throw new Error("Method not implemented.");
    }
    constructor(private http: HttpClient) {

    }
}