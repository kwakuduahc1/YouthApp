import { Observable } from "rxjs/Observable";
import { HttpErrorResponse } from "@angular/common/http";

export interface IHttpMethods<T> {
    find(id:string): Observable<T> | null;
    list(): Observable<T[]>;
    add(item: T): Observable<T>;
    edit(item: T): Observable<T>;
    delete(item: T): Observable<void>;
}