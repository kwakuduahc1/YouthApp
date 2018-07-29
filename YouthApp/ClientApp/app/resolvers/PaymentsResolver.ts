//import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
//import { Observable } from "rxjs/Observable";
//import { Injectable } from "@angular/core";
//import { IPayments } from "../models/IPayments";

//@Injectable()
//export class PaymentsResolver implements Resolve<Observable<IPayments[]>> {
//    resolve(route:ActivatedRouteSnapshot): Observable<IPayments[]>{
//        return this.http.getPayments(route.paramMap.get('id') as string);
//    }

//    constructor(private http: HttpProvider) {

//    }
//}