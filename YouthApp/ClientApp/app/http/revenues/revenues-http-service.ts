import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IHttpMethods } from '../IHttpMethods';
import { Observable } from 'rxjs/Observable';
import { IRevenues } from '../../models/IRevenues';

@Injectable()
export class RevenueHttpService implements IHttpMethods<IRevenues> {

    find(id: string): Observable<IRevenues> | null {
        return this.http.get<IRevenues>(`/Revenues/Find?id=${id}`)
    }

    list(): Observable<IRevenues[]> {
        return this.http.get<IRevenues[]>(`/Revenues/List`)
    }

    add(item: IRevenues): Observable<IRevenues> {
        return this.http.post<IRevenues>(`/Revenues/Create`, item)
    }

    edit(item: IRevenues): Observable<IRevenues> {
        return this.http.put<IRevenues>(`/Revenues/Edit`, item)
    }

    delete(item: IRevenues): Observable<void> {
        return this.http.post<void>(`/Revenues/Delete`, item)
    }

    constructor(private http: HttpClient) {

    }
}