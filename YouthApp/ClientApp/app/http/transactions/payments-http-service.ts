import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IHttpMethods } from '../IHttpMethods';
import { Observable } from 'rxjs/Observable';
import { ITransactions } from '../../models/ITransactions';
import { IBalances } from '../../models/IBalances';

@Injectable()
export class TransactionsHttpService {


    find(id: string): Observable<ITransactions> | null {
        return this.http.get<ITransactions>(`/Transactions/Find/${id}`)
    }

    search(qry: string): Observable<ITransactions[]> {
        return this.http.get<ITransactions[]>(`/Transactions/Search?qry=${qry}`);
    }

    list(): Observable<ITransactions[]> {
        return this.http.get<ITransactions[]>(`/Transactions/List`);
    }

    issue(item: ITransactions): Observable<ITransactions> {
        return this.http.post<ITransactions>('/Transactions/Issue', item);
    }

    receive(item: ITransactions): Observable<ITransactions> {
        return this.http.post<ITransactions>('/Transactions/Receive', item);
    }

    edit(item: ITransactions): Observable<ITransactions> {
        return this.http.put<ITransactions>('/Transactions/Edit', item);
    }

    delete(item: ITransactions): Observable<void> {
        return this.http.post<void>('/Transactions/Delete', item)
    }

    itemBalances(): Observable<IBalances[]> {
        return this.http.get<IBalances[]>("/Helpers/ItemBalances");
    }

    constructor(private http: HttpClient) {

    }
}