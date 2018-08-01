import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IHttpMethods } from '../IHttpMethods';
import { Observable } from 'rxjs/Observable';
import { IStudents } from '../../models/IStudents';
import { IIndividualBills } from '../../models/IIndBill';
import { not } from '@angular/compiler/src/output/output_ast';

@Injectable()
export class StudentsHttpService implements IHttpMethods<IStudents> {

    receive(bill: IIndividualBills): Observable<IIndividualBills> {
        return this.http.put<IIndividualBills>('/StudentBills/Receive', bill);
    }

    find(id: string): Observable<IStudents> | null {
        return this.http.get<IStudents>(`/Students/Find?id=${id}`)
    }

    list(): Observable<IStudents[]> {
        throw new Error("Not implemented");
        //return this.http.get<IStudents[]>(`/Students/List`)
    }

    classList(id: number): Observable<IStudents[]> {
        return this.http.get<IStudents[]>(`/Students/List/${id}`);
    }
    add(item: IStudents): Observable<IStudents> {
        return this.http.post<IStudents>(`/Students/Create`, item)
    }

    edit(item: IStudents): Observable<IStudents> {
        return this.http.put<IStudents>(`/Students/Edit`, item)
    }

    delete(item: IStudents): Observable<void> {
        return this.http.post<void>(`/Students/Delete`, item)
    }

    change(item: IStudents): Observable<IStudents> {
        return this.http.put<IStudents>(`/Students/Change`, item)
    }

    students(cid: number): Observable<IStudents[]> {
        return this.http.get<IStudents[]>(`Students/List/${cid}`);
    }

    billStd(bill: IIndividualBills): Observable<IIndividualBills> {
        return this.http.post<IIndividualBills>('/StudentBills/AddBill', bill);
    }

    stdBill(std: number): Observable<IIndividualBills[]> {
        return this.http.get<IIndividualBills[]>(`/StudentBills/GetBill/${std}`);
    }

    constructor(private http: HttpClient) {

    }
}