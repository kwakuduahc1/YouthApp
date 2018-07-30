import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IHttpMethods } from '../IHttpMethods';
import { IBillItems } from '../../models/IBillItems';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class BillItemHttpService implements IHttpMethods<IBillItems> {
    find(id: string): Observable<IBillItems> | null {
        return this.http.get<IBillItems>(`/BillItems/Find?id=${id}`)
    }
    list(): Observable<IBillItems[]> {
        return this.http.get<IBillItems[]>(`/BillItems/List`)
    }
    add(item: IBillItems): Observable<IBillItems> {
        return this.http.post<IBillItems>(`/BillItems/Create`, item)
    }
    edit(item: IBillItems): Observable<IBillItems> {
        return this.http.put<IBillItems>(`/BillItems/Edit`, item)
    }
    delete(item: IBillItems): Observable<void> {
        return this.http.post<void>(`/BillItems/Delete`, item)
    }
    constructor(private http: HttpClient) {

    }
}