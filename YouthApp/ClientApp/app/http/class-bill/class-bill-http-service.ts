import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IHttpMethods } from '../IHttpMethods';
import { Observable } from 'rxjs/Observable';
import { IClassBills } from '../../models/IClassBill';
import { IBillsVm } from '../../models/IBill';
import { IStudentBill } from '../../models/IStudentBill';

@Injectable()
export class ClassBillHttpService {

    find(id: string): Observable<IClassBills> | null {
        return this.http.get<IClassBills>(`/ClassBills/Find?id=${id}`)
    }

    list(): Observable<IClassBills[]> {
        return this.http.get<IClassBills[]>(`/ClassBills/List`)
    }

    add(item: IClassBills): Observable<IClassBills> {
        return this.http.post<IClassBills>(`/ClassBills/Create`, item)
    }

    addBill(item: IBillsVm[]): Observable<IClassBills> {
        return this.http.post<IClassBills>(`/ClassBills/Create`, item)
    }

    edit(item: IClassBills): Observable<IClassBills> {
        return this.http.put<IClassBills>(`/ClassBills/Edit`, item)
    }

    delete(item: IClassBills): Observable<void> {
        return this.http.post<void>(`/ClassBills/Delete`, item)
    }

    change(item: IClassBills): Observable<IClassBills> {
        return this.http.put<IClassBills>(`/ClassBills/Change`, item)
    }

    termly(i: { year: number, classid: number }): Observable<IClassBills[]> {
        return this.http.get<IClassBills[]>(`/ClassBills/Bill?year=${i.year}&classid=${i.classid}`)
    }

    getClassbill(term: number, _class: number): Observable<IStudentBill[]> {
        return this.http.get<IStudentBill[]>(`/ClassBills/ClassBill?term=${term}&classid=${_class}`);
    }

    constructor(private http: HttpClient) {

    }
}