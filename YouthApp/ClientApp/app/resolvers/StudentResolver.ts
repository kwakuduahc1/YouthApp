//import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
//import { Observable } from "rxjs/Observable";
//import { Injectable } from "@angular/core";
//import { IStudents } from "../models/IStudents";

//@Injectable()
//export class StudentResolver implements Resolve<Observable<IStudents>> {
//    resolve(route: ActivatedRouteSnapshot): Observable<IStudents> {
//        return this.http.getStudent(route.paramMap.get("id") as string);
//    }

//    constructor(private http: HttpProvider) {

//    }
//}