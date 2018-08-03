import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IHttpMethods } from '../IHttpMethods';
import { Observable } from 'rxjs/Observable';
import { ITransactionItems } from '../../models/ItranItems';

@Injectable()
export class TransactionItemsHttpService implements IHttpMethods<ITransactionItems>  {


    find(id: string): Observable<ITransactionItems> | null {
       return this.http.get<ITransactionItems>(`/TransactionItems/Find/${id}`)
    }

    list(): Observable<ITransactionItems[]> {
        return this.http.get<ITransactionItems[]>(`/TransactionItems/List`);
    }
    add(item: ITransactionItems): Observable<ITransactionItems> {
        return this.http.post<ITransactionItems>('/TransactionItems/Create', item);
    }
    edit(item: ITransactionItems): Observable<ITransactionItems> {
        throw new Error("Method not implemented.");
    }
    delete(item: ITransactionItems): Observable<void> {
        throw new Error("Method not implemented.");
    }
    constructor(private http: HttpClient) {

    }
}