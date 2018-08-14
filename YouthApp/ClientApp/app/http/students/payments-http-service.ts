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


    find(id: string): Observable<IPayments> {
        return this.http.get<IPayments>(`/Payments/Find?id=${id}`);
    }

    list(id:number): Observable<IPayments[]> {
        return this.http.get<IPayments[]>(`/Payments/Student/${id}`);
    }

    add(item: IPayments): Observable<IPayments> {
        return this.http.post<IPayments>('/Payments/Create', item);
    }

    edit(item: IPayments): Observable<IPayments> {
        return this.http.put<IPayments>("/Payments/Edit", item);
    }

    delete(item: IPayments): Observable<void> {
        return this.http.post<void>("/Payments/Delete", item);
    }
    constructor(private http: HttpClient) {

    }
}