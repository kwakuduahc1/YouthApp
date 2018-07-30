import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IHttpMethods } from '../IHttpMethods';
import { Observable } from 'rxjs/Observable';
import { IMainClasses } from '../../models/IClasses';

@Injectable()
export class ClassesHttpService implements IHttpMethods<IMainClasses> {

    find(id: string): Observable<IMainClasses> | null {
        return this.http.get<IMainClasses>(`/Classes/Find?id=${id}`)
    }

    list(): Observable<IMainClasses[]> {
        return this.http.get<IMainClasses[]>(`/Classes/List`)
    }

    add(item: IMainClasses): Observable<IMainClasses> {
        return this.http.post<IMainClasses>(`/Classes/Create`, item)
    }

    edit(item: IMainClasses): Observable<IMainClasses> {
        return this.http.put<IMainClasses>(`/Classes/Edit`, item)
    }

    delete(item: IMainClasses): Observable<void> {
        return this.http.post<void>(`/Classes/Delete`, item)
    }

    change(item: IMainClasses): Observable<IMainClasses> {
        return this.http.put<IMainClasses>(`/Classes/Change`, item)
    }

    constructor(private http: HttpClient) {

    }
}