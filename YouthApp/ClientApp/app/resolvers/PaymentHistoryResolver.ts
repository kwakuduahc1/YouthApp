//import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
//import { Observable } from "rxjs/Observable";
//import { Injectable } from "@angular/core";
//import { HttpProvider } from "../providers/HttpProvider";
//import { IPayments } from "../models/IPayments";

//@Injectable()
//export class PaymentHistoryResolver implements Resolve<Observable<any[]>> {
//    resolve(route:ActivatedRouteSnapshot): Observable<any[]>{
//        return this.http.payHistory(route.paramMap.get('id') as string);
//    }

//    constructor(private http: HttpProvider) {

//    }
//}