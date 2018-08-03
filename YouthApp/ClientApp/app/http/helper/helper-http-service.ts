import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IHttpMethods } from '../IHttpMethods';
import { Observable } from 'rxjs/Observable';
import { IMainClasses } from '../../models/IClasses';
import { ITerms } from '../../models/Iterms';
import { IPaymentsSum } from '../../models/IPaymentsSum';
import { IDebtors } from '../../models/IDebtors';
import { ITransactionsTypes } from '../../models/ITransactionTypes';
import { ITransactions } from '../../models/ITransactions';

@Injectable()
export class HelperHttpService {

    getTerms(): Observable<ITerms[]> {
        return this.http.get<ITerms[]>(`/Helpers/Terms`)
    }

    payments(): Observable<IPaymentsSum[]> {
        return this.http.get<IPaymentsSum[]>("/Helpers/Payments/");
    }

    debtors(): Observable<IDebtors[]> {
        return this.http.get<IDebtors[]>("/Helpers/Debtors");
    }

    types(): Observable<ITransactionsTypes[]> {
        return this.http.get<ITransactionsTypes[]>("/Helpers/TransactionTypes");
    }

    yearGroups(): Observable<number[]> {
        return this.http.get<number[]>("/Helpers/YearGroups");
    }
    constructor(private http: HttpClient) {

    }
}