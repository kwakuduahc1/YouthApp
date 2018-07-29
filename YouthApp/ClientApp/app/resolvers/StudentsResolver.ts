//import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
//import { Observable } from "rxjs/Observable";
//import { Injectable } from "@angular/core";
//import { HttpProvider } from "../providers/HttpProvider";
//import { IStudents } from "../models/IStudents";

//@Injectable()
//export class StudentsResolver implements Resolve<Observable<IStudents[]>> {
//    resolve(route: ActivatedRouteSnapshot): Observable<IStudents[]> {
//        return this.http.getClassList(parseInt(route.paramMap.get("id") as string));
//    }

//    constructor(private http: HttpProvider) {

//    }
//}