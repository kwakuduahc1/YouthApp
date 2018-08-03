import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IHttpMethods } from '../IHttpMethods';
import { Observable } from 'rxjs/Observable';
import { ITransactions } from '../../models/ITransactions';

@Injectable()
export class TransactionsHttpService implements IHttpMethods<ITransactions>  {


    find(id: string): Observable<ITransactions> | null {
       return this.http.get<ITransactions>(`/Transactions/Find/${id}`)
    }

    list(): Observable<ITransactions[]> {
        return this.http.get<ITransactions[]>(`/Transactions/List`);
    }
    add(item: ITransactions): Observable<ITransactions> {
        return this.http.post<ITransactions>('/Transactions/Create', item);
    }
    edit(item: ITransactions): Observable<ITransactions> {
        throw new Error("Method not implemented.");
    }
    delete(item: ITransactions): Observable<void> {
        throw new Error("Method not implemented.");
    }
    constructor(private http: HttpClient) {

    }
}